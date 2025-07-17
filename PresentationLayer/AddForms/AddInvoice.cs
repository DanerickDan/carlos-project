using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.InvoiceManagment;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using PresentationLayer.Print;

namespace PresentationLayer.AddForms
{
    public partial class AddInvoice : Form
    {
        private readonly InvoiceCodeGenerator _invoiceCodeGenerator;
        private readonly IProductService _productService;
        private readonly IClientService _clientService;
        private InvoiceDTO _invoiceDTO;
        private List<InvoiceDTO> _invoiceList;
        private readonly IInvoiceServices _invoiceServices;
        private readonly PdfService pdfService;
        private readonly PrintService printService;
        private readonly INcfService _ncfService;
        private bool invoiceTo = false;
        private bool invoiceFrom = false;
        private bool productSelected = false;
        private bool termSelected = false;

        public AddInvoice()
        {
            InitializeComponent();
            _clientService = new ClientServices();
            _productService = new ProductServices();
            _invoiceCodeGenerator = new InvoiceCodeGenerator();
            _invoiceDTO = new();
            _invoiceList = new();
            _invoiceServices = new InvoiceServices();
            printService = new();
            pdfService = new();
            _ncfService = new NcfService();
            lblNumFactura.Text = _invoiceCodeGenerator.GenerateInvoiceNumber();
            lblNumFactura.Visible = true;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblPedido.Text = _invoiceCodeGenerator.GenerateOrderNumber();
            txtPrecio.KeyPress += ValidarSoloNumeros;
            txtCantidad.KeyPress += ValidarSoloNumeros;

            ComboBoxSettings();
        }



        #region Events settings

        // Validations

        private void ValidarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Permite la entrada de teclas numéricas y el retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si la tecla presionada no es un dígito ni una tecla de retroceso, se bloquea
                e.Handled = true;
                // Muestra un mensaje de error si se desea
                MessageBox.Show("Este campo solo debe contener números.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento crear factura
        private async void btnCrear_Click(object sender, EventArgs e)
        {
            string actualSequence = "";
            var ncf_lot = new NcfLotDTO();
            if (is_ncf.Checked)
            {
                try
                {
                    ncf_lot = _ncfService.GetFirstAvailableLot("B01");
                    actualSequence = ncf_lot.TipoNCF + ncf_lot.SecuenciaActual.ToString("D8");
                    lblNcf.Text = actualSequence;
                    lblNcfVence.Text = ncf_lot.FechaExpiracion.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No hay lotes disponibles para el tipo NCF: B01");
                    return;
                }
            }
            // Verificar que los campos necesarios estén seleccionados
            if (invoiceFrom && invoiceTo && productSelected && termSelected)
            {
                // Crear la factura con los datos ingresados
                InvoiceDTO invoice = new()
                {
                    Number = Convert.ToInt32(lblNumFactura.Text),
                    Date = Convert.ToDateTime(lblFecha.Text),
                    NCF = actualSequence,
                    Description = txtDescrip.Texts,
                    Terms = lblTerminos.Text,
                    OrderNumber = Convert.ToInt32(lblPedido.Text),
                    SellerName = lblVendedor.Text,
                    ClientID = Convert.ToInt32(lblClienteId.Text),
                    Details = _invoiceDTO.Details,
                    Total = Convert.ToDouble(lblTotal.Text),
                    SubTotal = Convert.ToDouble(lblSubTotal.Text),
                    NcfLoteId = ncf_lot.Id,
                };

                // Agregar la factura a los servicios de la base de datos
                _invoiceServices.AddInvoice(invoice);

                // Crear el cliente con los datos ingresados
                ClientDTO clientDTO = new()
                {
                    ClientName = lblNombre.Text,
                    Code = Convert.ToInt32(lblCodigo.Text),
                    Address = lblDireccion.Text,
                    City = lblCiudad.Text,
                    PhoneNumber = lblTelefono.Text,
                    Email = lblEmail.Text,
                    Rnc = lblRnc.Text,
                    Fax = lblFax.Text
                };
                if (ncf_lot.PrefijoNCF != null)
                {
                    _ncfService.UpdateLot(ncf_lot);
                }
                // Preguntar si desea crear un PDF de la factura
                DialogResult result = MessageBox.Show("¿Deseas crear un PDF de la factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Cargar la plantilla HTML y llenar los datos de la factura y cliente
                string templatePath = Path.Combine(Application.StartupPath, "InvoiceTemplate/index.html");
                string templateHtml = File.ReadAllText(templatePath);
                string filledHtml = FillTemplate(templateHtml, invoice, clientDTO);

                // Inicializar los servicios para PDF y impresión
                var pdfService = new PdfService();
                var printService = new PrintService();

                // Generar el PDF con los estilos correctos
                byte[] pdfBytes = await pdfService.GeneratePdfAsync(filledHtml);

                // Verificar la decisión del usuario sobre la creación del PDF
                if (result == DialogResult.Yes)
                {
                    // El usuario desea crear el PDF y se le muestra la opción de guardar e imprimir
                    await printService.PrintAsync(pdfBytes, true);
                }
                else
                {
                    await printService.PrintAsync(pdfBytes, false);
                    // Solo se muestra mensaje de confirmación de adición de factura
                    MessageBox.Show("Factura agregada correctamente");
                }
                // Cerrar el formulario
                Close();
            }
            else
            {
                // Validaciones en caso de que no se hayan seleccionado los campos necesarios
                if (!invoiceFrom)
                {
                    MessageBox.Show("Debe seleccionar el remitente");
                }
                else if (!invoiceTo)
                {
                    MessageBox.Show("Debe seleccionar el destinatario");
                }
                else if (!productSelected)
                {
                    MessageBox.Show("No ha agregado ningún producto");
                }
                else if (!termSelected)
                {
                    MessageBox.Show("No ha seleccionado el término");
                }
            }
        }


        // Evento agregar Producto
        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            if (cbProductNombre.SelectedIndex >= 0)
            {
                int id = (int)cbProductNombre.SelectedValue;
                var products = _productService.GetByIdProduct(id);
                ProductsDTO productsDTO = new()
                {
                    ProductName = products.ProductName,
                    Lote = products.Lote,
                    Code = products.Code

                };

                InvoiceDetailsDTO details = new()
                {

                    ProductId = id,
                    Price = Convert.ToDouble(txtPrecio.Texts),
                    Quantity = Convert.ToInt32(txtCantidad.Texts),
                    Neto = Convert.ToDouble(txtNeto.Texts),
                    ProductName = productsDTO.ProductName,
                    Lote = productsDTO.Lote,
                    ProductCode = productsDTO.Code,


                };
                // Fix total and subTotal logic
                _invoiceDTO.Details.Add(details);
                var detalles = _invoiceDTO.Details;
                // Adding the Total
                double total = 0;
                foreach (var item in detalles)
                {
                    total += item.Neto;
                }
                lblTotal.Text = total.ToString();
                lblSubTotal.Text = total.ToString();
                FillInvoiceExample(details, null);
                CleanTxt();
                productSelected = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto");
            }
        }

        // Evento cambio de txt Cantidad
        private void txtCantidad__TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Texts == "")
            {
                txtCantidad.Texts = 0.ToString();
            }
            else if (txtPrecio.Texts == "")
            {
                txtPrecio.Texts = 0.ToString();
            }
            txtNeto.Texts = (Convert.ToDouble(txtPrecio.Texts) * Convert.ToInt32(txtCantidad.Texts)).ToString();
        }



        // Evento cambio de txt Precio
        private void txtPrecio__TextChanged(object sender, EventArgs e)
        {
            txtNeto.Texts = (Convert.ToDouble(txtPrecio.Texts) * Convert.ToInt32(txtCantidad.Texts)).ToString();
        }

        // Evento seleccion de termino
        private void cbTerminos_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string termino = cbTerminos.SelectedItem.ToString();
            lblTerminos.Text = termino;
            lblTerminos.Visible = true;
            termSelected = true;
        }
        // Evento seleccion de vendedor
        private void cbFacturaDe_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string vendedor = cbFacturaDe.SelectedItem.ToString();
            lblVendedor.Text = vendedor;
            lblVendedor.Visible = true;
            invoiceFrom = true;
        }

        #endregion

        #region Others Methods
        private void FillInvoiceExample(InvoiceDetailsDTO detail, ClientDTO client)
        {
            if (detail != null)
            {
                lblCodigoPr.Text = detail.ProductCode;
                lblDescrPr.Text = detail.ProductName;
                lblLote.Text = detail.Lote.ToString();
                lblCantidad.Text = detail.Quantity.ToString();
                lblPrecio.Text = detail.Price.ToString();
                lblNeto.Text = detail.Neto.ToString();
                // Visible
                lblCodigoPr.Visible = true;
                lblDescrPr.Visible = true;
                lblLote.Visible = true;
                lblCantidad.Visible = true;
                lblPrecio.Visible = true;
                lblNeto.Visible = true;

            }
            if (client != null)
            {
                lblClienteId.Text = client.ClientId.ToString();
                lblCodigo.Text = client.Code.ToString();
                lblNombre.Text = client.ClientName;
                lblDireccion.Text = client.Address;
                lblCiudad.Text = client.City;
                lblTelefono.Text = client.PhoneNumber;
                lblRnc.Text = client.Rnc;
                lblEmail.Text = client.Email;
                lblFax.Text = client.Fax;

                // Visible
                lblCodigo.Visible = true;
                lblNombre.Visible = true;
                lblDireccion.Visible = true;
                lblCiudad.Visible = true;
                lblTelefono.Visible = true;
                lblRnc.Visible = true;
                lblFax.Visible = true;
            }
        }

        private string FillTemplate(string template, InvoiceDTO invoice, ClientDTO client)
        {
            string logoPath = Path.Combine(Application.StartupPath, "InvoiceTemplate", "ROCAPHARMA.jpg");

            string base64Logo = Convert.ToBase64String(File.ReadAllBytes(logoPath));
            string imageSrc = $"data:image/jpeg;base64,{base64Logo}";

            template = template.Replace("{{logo_base64}}", imageSrc);

            string ncfHtml = "";

            if (!string.IsNullOrWhiteSpace(invoice.NCF))
            {
                // Buscar fecha de vencimiento del NCF usando el ID del lote
                var lote = _ncfService.GetNcfLotDTOById(invoice.NcfLoteId); // Asegúrate que este campo esté en InvoiceDTO

                ncfHtml = $@"
                    <p class=""font-bold"">FACTURA DE CREDITO FISCAL</p>
                    <p>NCF: {invoice.NCF}</p>
                    <p>Válida hasta: {lote.FechaExpiracion:dd/MM/yyyy}</p>";
            }
            else
            {
                ncfHtml = @"<p class=""font-bold"">CONSUMIDOR FINAL</p>";
            }

            // Reemplazar los marcadores de posición en la plantilla con los datos de la factura
            template = template.Replace("{{ClientName}}", client.ClientName)
                               .Replace("{{ClientCode}}", client.Code.ToString())
                               .Replace("{{ClientAddress}}", client.Address)
                               .Replace("{{ClientCity}}", client.City)
                               .Replace("{{ClientPhone}}", client.PhoneNumber)
                               .Replace("{{ClientRNC}}", client.Rnc)
                               .Replace("{{SellerName}}", invoice.SellerName)
                               .Replace("{{NCF}}", invoice.NCF)
                               .Replace("{{NCF_Vencimiento}}",lblNcfVence.Text)
                               .Replace("{{Terms}}", invoice.Terms)
                               .Replace("{{OrderNumber}}", invoice.OrderNumber.ToString("D4"))
                               .Replace("{{InvoiceNumber}}", invoice.Number.ToString("D4"))
                               .Replace("{{NCF_BLOCK}}", ncfHtml)
                               .Replace("{{Date}}", invoice.Date.ToString("dd/MM/yyyy"));

            // Reemplazar los productos
            string productTemplate = @"
                <tr>
                <td class=""border-b py-3 pl-3"">{{ProductCode}}</td>
                <td class=""border-b py-3 pl-2 text-center"">{{ProductName}}</td>
                <td class=""border-b py-3 pl-2 text-center"">{{Lote}}</td>
                <td class=""border-b py-3 pl-2 text-center"">{{Quantity}}</td>
                <td class=""border-b py-3 pl-2 text-center"">${{Price}}</td>
                <td class=""border-b py-3 pl-2 text-right"">${{Neto}}</td
                </tr>";

            string productsHtml = "";
            foreach (var product in invoice.Details)
            {
                if (!string.IsNullOrEmpty(product.ProductCode) && !string.IsNullOrEmpty(product.ProductName))
                {
                    string productHtml = productTemplate.Replace("{{ProductCode}}", product.ProductCode.ToString())
                                                        .Replace("{{ProductName}}", product.ProductName)
                                                        .Replace("{{Lote}}", product.Lote.ToString())
                                                        .Replace("{{Quantity}}", product.Quantity.ToString())
                                                        .Replace("{{Price}}", product.Price.ToString("F2"))
                                                        .Replace("{{Neto}}", product.Neto.ToString("F2"));
                    productsHtml += productHtml;
                }
            }
            template = template.Replace("<!-- Productos -->", productsHtml);

            template = template.Replace("{{SubTotal}}", invoice.SubTotal.ToString("F2"))
                               .Replace("{{Total}}", invoice.Total.ToString("F2"));

            return template;

        }

        private void CleanTxt()
        {
            // Desactivar temporalmente el evento OnSelectedIndexChanged para evitar cambios automáticos
            cbProductNombre.OnSelectedIndexChanged -= cbProductNombre_OnSelectedIndexChanged;

            // Limpiar y asegurarse de que SelectedIndex sea -1
            cbProductNombre.SelectedIndex = -1;
            cbProductNombre.Texts = "";

            // Verificar si el índice es realmente -1; si no, forzarlo de nuevo
            if (cbProductNombre.SelectedIndex != -1)
            {
                cbProductNombre.SelectedItem = null;
                cbProductNombre.SelectedIndex = -1;
            }

            // Reactivar el evento después de los cambios
            cbProductNombre.OnSelectedIndexChanged += cbProductNombre_OnSelectedIndexChanged;

            // Limpiar los otros campos de texto
            txtCantidad.Texts = "";
            txtPrecio.Texts = "";
            txtNeto.Texts = "";
        }
        #endregion

        //------

        #region ComboBoxSettings

        private void ComboBoxSettings()
        {
            var clientData = _clientService.GetAllCLientName();
            var productData = _productService.GetInvoiceProducts();

            // ComboBox client Names
            cbFacturaPara.DataSource = clientData;
            cbFacturaPara.DisplayMember = "ClientName";
            cbFacturaPara.ValueMember = "ClientId";
            cbFacturaPara.Texts = "";

            // ComboBox product Names
            cbProductNombre.DataSource = productData;
            cbProductNombre.DisplayMember = "ProductName";
            cbProductNombre.ValueMember = "ProductsId";
            cbProductNombre.Texts = "";
            cbProductNombre.SelectedItem = null;

            // Assigning the selectedIndexChanged Event
            cbFacturaPara.OnSelectedIndexChanged += cbFacturaPara_OnSelectedIndexChanged;
            cbProductNombre.OnSelectedIndexChanged += cbProductNombre_OnSelectedIndexChanged;
        }

        private void cbFacturaPara_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedClient = (int)cbFacturaPara.SelectedValue;
            var clientDTO = _clientService.GetByIdClient(selectedClient);
            ClientDTO client = new()
            {
                ClientId = selectedClient,
                ClientName = clientDTO.ClientName,
                Code = clientDTO.Code,
                Address = clientDTO.Address,
                City = clientDTO.City,
                PhoneNumber = clientDTO.PhoneNumber,
                Email = clientDTO.Email,
                Rnc = clientDTO.Rnc,
                Fax = clientDTO.Fax
            };
            FillInvoiceExample(null, client);
            invoiceTo = true;
        }

        private void cbProductNombre_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //cbProductNombre.SelectedValue = cbFacturaPara.SelectedValue;
            int selectedProduct = (int)cbProductNombre.SelectedValue;
            var productDTO = _productService.GetByIdProduct(selectedProduct);
            txtPrecio.Texts = productDTO.Price.ToString();
            txtCantidad.Texts = productDTO.Quantity.ToString();
            txtNeto.Texts = (Convert.ToDouble(txtPrecio.Texts) * Convert.ToInt32(txtCantidad.Texts)).ToString();
            txtCantidad._TextChanged += txtCantidad__TextChanged;

            //txtPrecio._TextChanged += txtPrecio__TextChanged;

        }

        #endregion

        private void cbProductNombre_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {
            //cbProductNombre.SelectedValue = cbFacturaPara.SelectedValue;
            int selectedProduct = (int)cbProductNombre.SelectedValue;
            var productDTO = _productService.GetByIdProduct(selectedProduct);
            txtPrecio.Texts = productDTO.Price.ToString();
            txtCantidad.Texts = productDTO.Quantity.ToString();
            txtNeto.Texts = (Convert.ToDouble(txtPrecio.Texts) * Convert.ToInt32(txtCantidad.Texts)).ToString();
            txtCantidad._TextChanged += txtCantidad__TextChanged;

            //txtPrecio._TextChanged += txtPrecio__TextChanged;
        }

        private void AddInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
