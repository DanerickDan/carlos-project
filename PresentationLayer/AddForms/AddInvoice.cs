using BusinessLayer.Interfaces.IServices;
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
        private readonly InvoiceDTO _invoiceDTO;
        private readonly List<InvoiceDTO> _invoiceList;


        public AddInvoice()
        {
            InitializeComponent();
            _clientService = new ClientServices();
            _productService = new ProductServices();
            _invoiceCodeGenerator = new InvoiceCodeGenerator();
            _invoiceDTO = new();
            _invoiceList = new();
            lblNumFactura.Text = _invoiceCodeGenerator.InvoiceNumber();
            lblNumFactura.Visible = true;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblPedido.Text = _invoiceCodeGenerator.OrderNumber();
            ComboBoxSettings();
        }


        //private InvoiceDTO MappingInvoice()
        //{
        //    if (dataGridView1.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
        //        int invoiceId = Convert.ToInt32(selectedRow.Cells[0].Value);
        //        int orderNumber = Convert.ToInt32(selectedRow.Cells[1].Value);
        //        DateTime date = Convert.ToDateTime(selectedRow.Cells[2].Value);
        //        string terms = selectedRow.Cells[3].Value.ToString();
        //        int clientId = Convert.ToInt32(selectedRow.Cells[4].Value);
        //        string sellerName = selectedRow.Cells[5].Value.ToString();
        //        double neto = Convert.ToDouble(selectedRow.Cells[6].Value);
        //        double price = Convert.ToDouble(selectedRow.Cells[7].Value);
        //        double total = Convert.ToDouble(selectedRow.Cells[8].Value);
        //        int lote = Convert.ToInt32(selectedRow.Cells[9].Value);
        //        string ncf = selectedRow.Cells[10].Value.ToString();
        //        int quantity = Convert.ToInt32(selectedRow.Cells[11].Value);
        //        string productCode = selectedRow.Cells[12].Value.ToString();
        //        double subTotal = Convert.ToDouble(selectedRow.Cells[13].Value);
        //        int productId = Convert.ToInt32(selectedRow.Cells[14].Value);
        //        int invoiceNumber = Convert.ToInt32(selectedRow.Cells[15].Value);

        //        // TODO: rethink this 
        //        List<InvoiceDetailsDTO> details = new List<InvoiceDetailsDTO>();
        //        InvoiceDetailsDTO detailsItem = new InvoiceDetailsDTO();

        //        detailsItem.InvoiceId = invoiceId;
        //        detailsItem.ProductId = productId;
        //        detailsItem.Lote = lote;
        //        detailsItem.Quantity = quantity;
        //        detailsItem.ProductCode = productCode;
        //        detailsItem.Price = price;
        //        detailsItem.Neto = neto;
        //        detailsItem.SubTotal = subTotal;
        //        detailsItem.Total = total;
        //        details.Add(detailsItem);

        //        InvoiceDTO invoice = new InvoiceDTO
        //        {
        //            InvoiceID = invoiceId,
        //            Date = date,
        //            Number = invoiceNumber,
        //            NCF = ncf,
        //            Terms = terms,
        //            OrderNumber = orderNumber,
        //            SellerName = sellerName,
        //            ClientID = clientId

        //        };
        //        return invoice;
        //    }
        //    return null;
        //}

        #region Events settings

        // Evento crear factura
        private void btnCrear_Click(object sender, EventArgs e)
        {

        }

        // Evento agregar Producto
        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            if (cbProductNombre.SelectedItem != null)
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
                _invoiceDTO.Details.Add(details);
                var detalles = _invoiceDTO.Details;
                // Adding the Total
                double total = 0;
                foreach (var item in detalles)
                {
                    total += item.Neto;
                }
                lblTotal.Text = "$" + total;
                lblSubTotal.Text = "$" + total;
                FillInvoiceExample(details, null);
                CleanTxt();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto");
            }
        }

        // Evento cambio de txt Cantidad
        private void txtCantidad__TextChanged(object sender, EventArgs e)
        {
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
        }
        // Evento seleccion de vendedor
        private void cbFacturaDe_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string vendedor = cbFacturaDe.SelectedItem.ToString();
            lblVendedor.Text = vendedor;
            lblVendedor.Visible = true;
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
                lblCodigo.Text = client.Code.ToString();
                lblNombre.Text = client.ClientName;
                lblDireccion.Text = client.Address;
                lblCiudad.Text = client.City;
                lblTelefono.Text = client.PhoneNumber;

                // Visible
                lblCodigo.Visible = true;
                lblNombre.Visible = true;
                lblDireccion.Visible = true;
                lblCiudad.Visible = true;
                lblTelefono.Visible = true;
            }
        }

        private void CleanTxt()
        {
            cbProductNombre.Texts = "";
            txtCantidad.Texts = "";
            txtPrecio.Texts = "";
            txtNeto.Texts = "";
            cbProductNombre.SelectedItem = null;
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
                ClientName = clientDTO.ClientName,
                Code = clientDTO.Code,
                Address = clientDTO.Address,
                City = clientDTO.City,
                PhoneNumber = clientDTO.PhoneNumber,

            };
            FillInvoiceExample(null, client);
        }

        private void cbProductNombre_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            cbProductNombre.SelectedValue = cbFacturaPara.SelectedValue;
            int selectedProduct = (int)cbProductNombre.SelectedValue;
            var productDTO = _productService.GetByIdProduct(selectedProduct);
            txtPrecio.Texts = productDTO.Price.ToString();
            txtCantidad.Texts = productDTO.Quantity.ToString();
            txtNeto.Texts = (Convert.ToDouble(txtPrecio.Texts) * Convert.ToInt32(txtCantidad.Texts)).ToString();
            //txtCantidad._TextChanged += txtCantidad__TextChanged;
            //txtPrecio._TextChanged += txtPrecio__TextChanged;

        }

        #endregion


    }
}
