using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.InvoiceManagment;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using DomainLayer.Entities;
using PresentationLayer.AddForms;
using PresentationLayer.Features;
using PresentationLayer.Print;
using System.ComponentModel;

namespace PresentationLayer
{
    public partial class InvoiceForm : Form
    {
        private readonly IInvoiceServices invoiceServices;
        private readonly PrintService printService;
        private readonly Mapping mapping;
        private BindingList<InvoiceGridViewDTO> InvoiceBindingList;
        private readonly PdfService pdfService;
        private readonly CreateCSV _createCSV;
        private readonly INcfService _ncfService;

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
            _ncfService = new NcfService();
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

        // Add Ncf Lots
        private void add_lot_Click(object sender, EventArgs e)
        {
            AddLot addInvoice = new();
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

        private void DataGridSettings()
        {
            dataGridView1.AutoGenerateColumns = false;
        }


        // Print Invoice
        private async void btnImprimir_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int inoviceId = (int)dataGridView1.SelectedRows[0].Cells["InvoiceId"].Value; // Ajusta "" según tu columna

                // Preguntar si desea crear un PDF de la factura
                DialogResult result = MessageBox.Show("¿Deseas crear un PDF de la factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Cargar la plantilla HTML y llenar los datos de la factura y cliente

                var invoice = printService.GetInvoicePrintById(inoviceId);
                ClientDTO clientDTO = new()
                {
                    ClientId = invoice.ClientId,
                    ClientName = invoice.ClientName,
                    Address = invoice.ClientAddress,
                    City = invoice.ClientCity,
                    Email = invoice.ClientEmail,
                    PhoneNumber = invoice.ClientPhone,
                    Rnc = invoice.ClientRNC,
                    Code = invoice.ClientCode,

                };

                string templatePath = Path.Combine(Application.StartupPath, "InvoiceTemplate/index.html");
                string templateHtml = File.ReadAllText(templatePath);
                string filledHtml = FillTemplate(templateHtml, invoice);

                // Inicializar los servicios para PDF y impresión

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
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una factura");
            }
        }

        public string FillTemplate(string template, PrintViewDTO data)
        {
            var Ncf_lote = _ncfService.GetNcfLotDTOById(data.LoteNcfId);
            string logoPath = Path.Combine(Application.StartupPath, "InvoiceTemplate", "ROCAPHARMA.jpg");

            string base64Logo = Convert.ToBase64String(File.ReadAllBytes(logoPath));
            string imageSrc = $"data:image/jpeg;base64,{base64Logo}";

            template = template.Replace("{{logo_base64}}", imageSrc);

            // Construir bloque condicional del NCF
            string ncfHtml = "";
            if (!string.IsNullOrWhiteSpace(data.NCF))
            {
                ncfHtml = $@"
                    <p class=""font-bold"">FACTURA DE CREDITO FISCAL</p>
                    <p>NCF: {data.NCF}</p>
                    <p>Válida hasta: {Ncf_lote.FechaExpiracion:dd/MM/yyyy}</p>";
            }
            else
            {
                ncfHtml = $@"
                    <p class=""font-bold"">CONSUMIDOR FINAL</p>";
            }

                // Reemplazar los datos generales en la plantilla
                template = template.Replace("{{ClientName}}", data.ClientName)
                                   .Replace("{{ClientCode}}", data.ClientCode.ToString())
                                   .Replace("{{ClientAddress}}", data.ClientAddress.ToString())
                                   .Replace("{{ClientCity}}", data.ClientCity.ToString())
                                   .Replace("{{ClientPhone}}", data.ClientPhone.ToString())
                                   .Replace("{{ClientRNC}}", data.ClientRNC.ToString())
                                   .Replace("{{SellerName}}", data.SellerName)
                                   .Replace("{{Terms}}", data.InvoiceTerms)
                                   .Replace("{{OrderNumber}}", data.OrderNumber.ToString("D4"))
                                   .Replace("{{InvoiceNumber}}", data.InvoiceNumber.ToString("D4"))
                                   .Replace("{{Date}}", data.Date.ToString("dd/MM/yyyy"))
                                   .Replace("{{SubTotal}}", data.SubTotal.ToString("F2"))
                                   .Replace("{{Total}}", data.Total.ToString("F2"))
                                   .Replace("{{NCF_BLOCK}}", ncfHtml); // Reemplaza bloque del NCF

            // Reemplazar los productos
            string productTemplate = @"
                <tr>
                    <td class=""border-b py-3 pl-3"">{{ProductCode}}</td>
                    <td class=""border-b py-3 pl-2 text-center"">{{ProductName}}</td>
                    <td class=""border-b py-3 pl-2 text-center"">{{Lote}}</td>
                    <td class=""border-b py-3 pl-2 text-center"">{{Quantity}}</td>
                    <td class=""border-b py-3 pl-2 text-center"">${{Price}}</td>
                    <td class=""border-b py-3 pl-2 text-right"">${{Neto}}</td>
                </tr>";

            string productsHtml = "";
            foreach (var product in data.products)
            {
                string productHtml = productTemplate.Replace("{{ProductCode}}", product.Code.ToString())
                                                    .Replace("{{ProductName}}", product.ProductName.ToString())
                                                    .Replace("{{Lote}}", product.Lote.ToString())
                                                    .Replace("{{Quantity}}", product.Quantity.ToString())
                                                    .Replace("{{Price}}", product.Price.ToString("F2"))
                                                    .Replace("{{Neto}}", product.ProductNeto.ToString("F2"));
                productsHtml += productHtml;
            }

            template = template.Replace("<!-- Productos -->", productsHtml);
            return template;
        }


        // Get all invoices
        private void GetAllInvoice()
        {
            var invoice = invoiceServices.GetInvoicesGrid();
            InvoiceBindingList = new BindingList<InvoiceGridViewDTO>(invoice);
            dataGridView1.DataSource = InvoiceBindingList;
            lblTotalRegistros.Text = invoice.Count.ToString();
            lblFiltrados.Text = invoice.Count.ToString();

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

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            // Obtén el término de búsqueda del TextBox
            string searchTerm = txtSearch.Texts.Trim();

            // Filtra los datos en memoria usando LINQ sobre ClientBindingList
            var filteredInvoice = InvoiceBindingList
                .Where(i => i.Terms.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            i.SellerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            i.ClientName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            i.InvoiceNumber.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            i.Date.ToString().Contains(searchTerm))
                .ToList();

            // Actualiza el DataGridView con los resultados filtrados
            UpdateDataGridView(filteredInvoice);
        }

        private void UpdateDataGridView(List<InvoiceGridViewDTO> filteredInvoice)
        {
            // Asigna los resultados filtrados al DataGridView
            dataGridView1.DataSource = new BindingList<InvoiceGridViewDTO>(filteredInvoice);

            // Actualiza los labels de conteo
            lblFiltrados.Text = filteredInvoice.Count.ToString();
        }
    }
}
