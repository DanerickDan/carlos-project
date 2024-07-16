using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;

namespace PresentationLayer
{
    public partial class InvoiceForm : Form
    {
        IInvoiceServices invoiceServices;
        public InvoiceForm()
        {
            InitializeComponent();
            invoiceServices = new InvoiceServices();
        }

        // Add Invoice
        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                DateTime date = Convert.ToDateTime(selectedRow.Cells[1].Value);
                string number = selectedRow.Cells[2].Value.ToString();
                string ncf = selectedRow.Cells[3].Value.ToString();
                string terms = selectedRow.Cells[4].Value.ToString();
                int orderNumer = Convert.ToInt32(selectedRow.Cells[5].Value);
                string sellerName = selectedRow.Cells[6].Value.ToString();
                // TODO: thinking about the foreings in the logic

                InvoiceDTO invoice = new InvoiceDTO
                {
                    Date = date,
                    Number = number,
                    NCF = ncf,
                    Terms = terms,
                    OrderNumer = orderNumer,
                    SellerName = sellerName
                };
                invoiceServices.AddInvoice(invoice);
            }
        }

        // Delete Invoice

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0) 
            {
                
            }
        }

        // Update Invoice
        private void btnEditar_Click(object sender, EventArgs e)
        {

        }


        // Print Invoice
        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
