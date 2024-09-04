using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.InvoiceManagment;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using DomainLayer.Entities;
using PresentationLayer.AddForms;
using PresentationLayer.Features;
using System.ComponentModel;
using System.Diagnostics;

namespace PresentationLayer
{
    public partial class InvoiceForm : Form
    {
        private readonly IInvoiceServices invoiceServices;
        private readonly Mapping mapping;
        private BindingList<InvoiceViewDTO> InvoiceBindingList;
        private readonly PdfService pdfService;
        private readonly PrintService printService;
        private readonly CreateCSV _createCSV;

        public InvoiceForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.InvoiceForm_Load);
            invoiceServices = new InvoiceServices();
            dataGridView1.MouseWheel += DataGridView1_MouseWheel;
            pdfService = new PdfService();
            printService = new PrintService();
            _createCSV = new();
            mapping = new();
        }

        // Add Invoice
        private void btnAnadir_Click(object sender, EventArgs e)
        {
            AddInvoice addInvoice = new();
            addInvoice.MaximizeBox = false;
            addInvoice.MinimizeBox = false;
            var result = addInvoice.ShowDialog();
            if (result == DialogResult.OK)
            {

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
                string productCode = selectedRow.Cells[12].Value.ToString();
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
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);


                // Cargar la plantilla HTML y llenar los datos de la factura
                string templatePath = Path.Combine(Application.StartupPath, "index.html");

                string templateHtml = File.ReadAllText(templatePath);
                var data = printService.GetInvoicePrintById(id);
                string filledHtml = FillTemplate(templateHtml, data);

                // Generar el PDF
                byte[] pdfBytes = pdfService.GeneratePdf(filledHtml);

                // Imprimir el PDF
                printService.Print(pdfBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string FillTemplate(string template, PrintViewDTO data)
        {

            // Reemplazar los marcadores de posición en la plantilla con los datos de la factura
            template = template.Replace("{{ClientName}}", data.NombreCliente)
                               .Replace("{{ClientCode}}", data.CodigoCliente.ToString())
                               .Replace("{{ClientAddress}}", data.ClienteDireccion.ToString())
                               .Replace("{{ClientCity}}", data.ClienteCiudad.ToString())
                               .Replace("{{ClientPhone}}", data.ClienteTelefono.ToString())
                               .Replace("{{ClientRNC}}", data.ClienteRNC.ToString())
                               .Replace("{{SellerName}}", data.Vendedor)
                               .Replace("{{NCF}}", data.NCF)
                               .Replace("{{Terms}}", data.Terminos)
                               .Replace("{{OrderNumber}}", data.NumeroPedido.ToString())
                               .Replace("{{InvoiceNumber}}", data.NumeroFactura.ToString())
                               .Replace("{{Date}}", data.Fecha.ToString("dd/MM/yyyy"))
                               .Replace("{{SubTotal}}", data.SubTotal.ToString("F2"))
                               .Replace("{{Total}}", data.Total.ToString("F2"));

            // Reemplazar los productos
            string productTemplate = @"
            <tr>
                <th scope=""row"">{{ProductCode}}</th>
                <td>{{ProductName}}</td>
                <td>{{Lote}}</td>
                <td>{{Quantity}}</td>
                <td>${{Price}}</td>
                <td>{{Neto}}</td>
            </tr>";
            string productsHtml = "";
            foreach (var product in data.products)
            {
                string productHtml = productTemplate.Replace("{{ProductCode}}", data.CodigoProducto.ToString())
                                                    .Replace("{{ProductName}}", data.NombreProducto.ToString())
                                                    .Replace("{{Lote}}", data.LoteProducto.ToString())
                                                    .Replace("{{Quantity}}", data.Cantidad.ToString())
                                                    .Replace("{{Price}}", data.PrecioUnitario.ToString("F2"))
                                                    .Replace("{{Neto}}", data.Neto.ToString("F2"));
                productsHtml += productHtml;
            }
            template = template.Replace("<!-- Products -->", productsHtml);

            return template;

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
            // Verificar que el índice no sea mayor que la cantidad de filas disponibles
            int newRowIndex = Math.Min(e.NewValue, dataGridView1.Rows.Count - 1);
            if (newRowIndex >= 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = newRowIndex;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Ajustar el máximo del scrollbar al número de filas - 1 para evitar IndexOutOfRange
            materialScrollBar1.Maximum = Math.Max(0, dataGridView1.RowCount - 1);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Ajustar el máximo del scrollbar al número de filas - 1 para evitar IndexOutOfRange
            materialScrollBar1.Maximum = Math.Max(0, dataGridView1.RowCount - 1);
        }

        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            int newValue = materialScrollBar1.Value;

            if (e.Delta > 0 && newValue > materialScrollBar1.Minimum)
            {
                newValue--;
            }
            else if (e.Delta < 0 && newValue < materialScrollBar1.Maximum)
            {
                newValue++;
            }

            // Verificar que el índice no sea mayor que la cantidad de filas disponibles
            if (newValue >= 0 && newValue < dataGridView1.RowCount)
            {
                materialScrollBar1.Value = newValue;
                dataGridView1.FirstDisplayedScrollingRowIndex = newValue;
            }
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            _createCSV.ExportarDataGridViewAExcel(dataGridView1);
        }
    }
}
