using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.InvoiceManagment;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;

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
            lblNumFactura.Text = _invoiceCodeGenerator.InvoiceNumber();
            lblNumFactura.Visible = true;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblPedido.Text = _invoiceCodeGenerator.OrderNumber();
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
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(invoiceFrom == true && invoiceTo == true && productSelected == true && termSelected == true)
            {
                InvoiceDTO invoice = new()
                {
                    Number = Convert.ToInt32(lblNumFactura.Text),
                    Date = Convert.ToDateTime(lblFecha.Text),
                    NCF = lblNcf.Text,
                    Description = txtDescrip.Texts,
                    Terms = lblTerminos.Text,
                    OrderNumber = Convert.ToInt32(lblPedido.Text),
                    SellerName = lblVendedor.Text,
                    ClientID = Convert.ToInt32(lblClienteId.Text),
                    Details = _invoiceDTO.Details,
                    Total = Convert.ToDouble(lblTotal.Text),
                    SubTotal = Convert.ToDouble(lblSubTotal.Text),
                };
                _invoiceServices.AddInvoice(invoice);
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
                DialogResult result = MessageBox.Show("¿Deseas crear un pdf de la factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    // Cargar la plantilla HTML y llenar los datos de la factura
                    string templatePath = Path.Combine(Application.StartupPath, "index.html");

                    string templateHtml = File.ReadAllText(templatePath);
                    string filledHtml = FillTemplate(templateHtml, invoice, clientDTO);

                    // Generar el PDF
                    byte[] pdfBytes = pdfService.GeneratePdf(filledHtml);

                    // Imprimir el PDF
                    printService.Print(pdfBytes);
                }
                else if (result == DialogResult.No)
                {
                    // Cargar la plantilla HTML y llenar los datos de la factura
                    string templatePath = Path.Combine(Application.StartupPath, "index.html");

                    string templateHtml = File.ReadAllText(templatePath);
                    string filledHtml = FillTemplate(templateHtml, invoice, clientDTO);

                    // Generar el PDF
                    byte[] pdfBytes = pdfService.GeneratePdf(filledHtml);

                    // Imprimir el PDF
                    printService.Print(pdfBytes, false);
                    MessageBox.Show("Factura agregada correctamente");
                }

                Close();
            }
            else if(invoiceFrom == false)
            {
                MessageBox.Show("Debe seleccionar el remitente");
            }
            else if(invoiceTo == false)
            {
                MessageBox.Show("Debe seleccionar el destinatario");
            }
            else if (productSelected == false)
            {
                MessageBox.Show("No ha agregado ningun producto");
            }
            else if(termSelected == false)
            {
                MessageBox.Show("No ha seleccionado el termino");
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
            if(txtCantidad.Texts == "")
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
            // Reemplazar los marcadores de posición en la plantilla con los datos de la factura
            template = template.Replace("{{ClientName}}", client.ClientName)
                               .Replace("{{ClientCode}}", client.Code.ToString())
                               .Replace("{{ClientAddress}}", client.Address)
                               .Replace("{{ClientCity}}", client.City)
                               .Replace("{{ClientPhone}}", client.PhoneNumber)
                               .Replace("{{ClientRNC}}", client.Rnc)
                               .Replace("{{SellerName}}", invoice.SellerName)
                               .Replace("{{NCF}}", invoice.NCF)
                               .Replace("{{Terms}}", invoice.Terms)
                               .Replace("{{OrderNumber}}", invoice.OrderNumber.ToString())
                               .Replace("{{InvoiceNumber}}", invoice.Number.ToString())
                               .Replace("{{Date}}", invoice.Date.ToString("dd/MM/yyyy"));

            // Reemplazar los productos
            string productTemplate = @"
                <tr>
                    <td>{{ProductCode}}</td>
                    <td>{{ProductName}}</td>
                    <td>{{Lote}}</td>
                    <td>{{Quantity}}</td>
                    <td>${{Price}}</td>
                    <td>{{Neto}}</td>
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
            template = template.Replace("<!-- Products -->", productsHtml);

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
    }
}
