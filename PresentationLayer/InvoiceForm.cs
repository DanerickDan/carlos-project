﻿using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.InvoiceManagment;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using System.ComponentModel;

namespace PresentationLayer
{
    public partial class InvoiceForm : Form
    {
        private readonly IInvoiceServices invoiceServices;
        private readonly Mapping mapping;
        private BindingList<InvoiceViewDTO> InvoiceBindingList;
        private readonly PdfService pdfService;
        private readonly PrintService printService;
        public InvoiceForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.InvoiceForm_Load);
            invoiceServices = new InvoiceServices();
            dataGridView1.MouseWheel += DataGridView1_MouseWheel;
            pdfService = new PdfService();
            printService = new PrintService();

            mapping = new();
        }

        // Add Invoice
        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int invoiceId = Convert.ToInt32(selectedRow.Cells[0].Value);
                int orderNumber = Convert.ToInt32(selectedRow.Cells[1].Value);
                DateTime date = Convert.ToDateTime(selectedRow.Cells[2].Value);
                string terms = selectedRow.Cells[3].Value.ToString();
                int clientId = Convert.ToInt32(selectedRow.Cells[4].Value);
                string sellerName = selectedRow.Cells[5].Value.ToString();
                double neto = Convert.ToDouble(selectedRow.Cells[6].Value);
                double price = Convert.ToDouble(selectedRow.Cells[7].Value);
                double total = Convert.ToDouble(selectedRow.Cells[8].Value);
                int lote = Convert.ToInt32(selectedRow.Cells[9].Value);
                string ncf = selectedRow.Cells[10].Value.ToString();
                int quantity = Convert.ToInt32(selectedRow.Cells[11].Value);
                string productCode = selectedRow.Cells[12].ToString();
                double subTotal = Convert.ToDouble(selectedRow.Cells[13].Value);
                int productId = Convert.ToInt32(selectedRow.Cells[14].Value);
                int invoiceNumber = Convert.ToInt32(selectedRow.Cells[15].Value);

                // TODO: rethink this 
                List<InvoiceDetailsDTO> details = new List<InvoiceDetailsDTO>();
                InvoiceDetailsDTO detailsItem = new InvoiceDetailsDTO();

                detailsItem.InvoiceId = invoiceId;
                detailsItem.ProductId = productId;
                detailsItem.Lote = lote;
                detailsItem.Quantity = quantity;
                detailsItem.ProductCode = productCode;
                detailsItem.Price = price;
                detailsItem.Neto = neto;
                detailsItem.SubTotal = subTotal;
                detailsItem.Total = total;
                details.Add(detailsItem);

                // TODO: thinking about the foreings in the logic

                InvoiceDTO invoice = new InvoiceDTO
                {
                    Date = date,
                    NCF = ncf,
                    Terms = terms,
                    OrderNumber = orderNumber,
                    SellerName = sellerName,
                    ClientID = clientId,
                    Details = details,
                    Number = invoiceNumber
                };
                invoiceServices.AddInvoice(invoice);
            }
        }

        // Delete Invoice
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta factura?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Código para eliminar la factura
                EliminarFactura();
            }

        }

        private void EliminarFactura()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int inoviceId = (int)dataGridView1.SelectedRows[0].Cells["InvoiceID"].Value; // Ajusta "" según tu columna

                // Llama al servicio para eliminar el producto de la base de datos
                invoiceServices.DeleteInvoice(inoviceId);

                // Elimina el producto de la lista de binding
                InvoiceBindingList.RemoveAt(rowIndex);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        // Update Invoice
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int invoiceId = Convert.ToInt32(selectedRow.Cells[0].Value);
                int orderNumber = Convert.ToInt32(selectedRow.Cells[1].Value);
                DateTime date = Convert.ToDateTime(selectedRow.Cells[2].Value);
                string terms = selectedRow.Cells[3].Value.ToString();
                int clientId = Convert.ToInt32(selectedRow.Cells[4].Value);
                string sellerName = selectedRow.Cells[5].Value.ToString();
                double neto = Convert.ToDouble(selectedRow.Cells[6].Value);
                double price = Convert.ToDouble(selectedRow.Cells[7].Value);
                double total = Convert.ToDouble(selectedRow.Cells[8].Value);
                int lote = Convert.ToInt32(selectedRow.Cells[9].Value);
                string ncf = selectedRow.Cells[10].Value.ToString();
                int quantity = Convert.ToInt32(selectedRow.Cells[11].Value);
                string productCode = selectedRow.Cells[12].ToString();
                double subTotal = Convert.ToDouble(selectedRow.Cells[13].Value);
                int productId = Convert.ToInt32(selectedRow.Cells[14].Value);
                int invoiceNumber = Convert.ToInt32(selectedRow.Cells[15].Value);

                // TODO: rethink this 
                List<InvoiceDetailsDTO> details = new List<InvoiceDetailsDTO>();
                InvoiceDetailsDTO detailsItem = new InvoiceDetailsDTO();

                detailsItem.InvoiceId = invoiceId;
                detailsItem.ProductId = productId;
                detailsItem.Lote = lote;
                detailsItem.Quantity = quantity;
                detailsItem.ProductCode = productCode;
                detailsItem.Price = price;
                detailsItem.Neto = neto;
                detailsItem.SubTotal = subTotal;
                detailsItem.Total = total;
                details.Add(detailsItem);

                InvoiceDTO invoice = new InvoiceDTO
                {
                    InvoiceID = invoiceId,
                    Date = date,
                    Number = invoiceNumber,
                    NCF = ncf,
                    Terms = terms,
                    OrderNumber = orderNumber,
                    SellerName = sellerName,
                    ClientID = clientId

                };
                invoiceServices.UpdateInvoice(invoice);
            }
        }

        private void DataGridSettings()
        {
            dataGridView1.AutoGenerateColumns = false;
        }


        // Print Invoice
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            // Cargar la plantilla HTML y llenar los datos de la factura
            string templatePath = Path.Combine(Application.StartupPath, "invoice_template.html");
            string templateHtml = File.ReadAllText(templatePath);
            string filledHtml = FillTemplate(templateHtml, invoiceData);

            // Generar el PDF
            byte[] pdfBytes = pdfService.GeneratePdf(filledHtml);

            // Imprimir el PDF
            printService.Print(pdfBytes);
        }

        // Get all invoices
        private void GetAllInvoice()
        {
            var invoice = mapping.GetInvoiceView();
            InvoiceBindingList = new BindingList<InvoiceViewDTO>(invoice);
            dataGridView1.DataSource = InvoiceBindingList;

        }


        // Get invoice By ids
        private void GetInvoiceById()
        {
            if (dataGridView1 == null)
            {
                // For the search system
                //dataGridView1.DataSource = invoiceServices.GetInvoiceById();
            }
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            DataGridSettings();
            GetAllInvoice();
        }

        private void materialScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[e.NewValue].Index;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            materialScrollBar1.Maximum = dataGridView1.RowCount;
        }


        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && materialScrollBar1.Value > materialScrollBar1.Minimum)
            {
                materialScrollBar1.Value--;
            }
            else if (e.Delta < 0 && materialScrollBar1.Value < materialScrollBar1.Maximum)
            {
                materialScrollBar1.Value++;
            }

            dataGridView1.FirstDisplayedScrollingRowIndex = materialScrollBar1.Value;
        }


        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            materialScrollBar1.Maximum = dataGridView1.RowCount;
        }

    }
}
