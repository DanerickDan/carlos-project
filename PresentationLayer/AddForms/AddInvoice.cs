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

        public AddInvoice()
        {
            InitializeComponent();
            _clientService = new ClientServices();
            _productService = new ProductServices();
            _invoiceCodeGenerator = new InvoiceCodeGenerator();
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


        private void btnCrear_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxSettings()
        {
            // ComboBox client Names
            cbFacturaPara.DataSource = _clientService.GetAllCLientName();
            cbFacturaPara.DisplayMember = "ClientName";
            cbFacturaPara.ValueMember = "ClientId";

            // ComboBox product Names
            cbProductNombre.DataSource = _productService.GetInvoiceProducts();
            cbProductNombre.DisplayMember = "ProductName";
            cbProductNombre.ValueMember = "ProductsId";
        }

        private void cbFacturaPara_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedClient = cbFacturaPara.SelectedIndex;
            var clientDTO = _clientService.GetByIdClient(selectedClient);
        }

        private void cbProductNombre_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedProduct = cbProductNombre.SelectedIndex;
            var productDTO = _productService.GetByIdProduct(selectedProduct);
            txtPrecio.Texts = productDTO.Price.ToString();
            txtCantidad.Texts = productDTO.Quantity.ToString();
        }

        private void txtCantidad__TextChanged(object sender, EventArgs e)
        {
            txtNeto.Texts = (Convert.ToInt32(txtPrecio.Texts) * Convert.ToInt32(txtCantidad.Texts)).ToString();
        }
    }
}
