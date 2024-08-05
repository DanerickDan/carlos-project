using BusinessLayer.InvoiceManagment;
using BusinessLayer.Model;


namespace PresentationLayer
{
    public partial class PrintForm : Form
    {
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private Print print;

        public PrintForm()
        {
            InitializeComponent();
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2
            {
                Dock = DockStyle.Fill
            };
            string templatePath = Path.Combine(Application.StartupPath, "invoice_template.html");
            print = new Print(templatePath);
            InitializeWebView2();
        }

        private async void InitializeWebView2()
        {
            this.Controls.Add(webView2);
            await webView2.EnsureCoreWebView2Async(null);

            // Ejemplo de datos de factura
            var invoiceData = new InvoiceViewDTO
            {
                ClientName = "Juan Perez",
                ClientCode = "12345",
                ClientAddress = "123 Calle Falsa",
                ClientCity = "Ciudad Falsa",
                ClientPhone = "123456789",
                ClientRNC = "987654321",
                SellerName = "Maria Gomez",
                NCF = "A00000001",
                Terms = "Contado",
                OrderNumber = "78910",
                InvoiceNumber = "0001",
                Date = DateTime.Now,
                SubTotal = 30.0,
                Total = 30.0,
                Products = new List<ProductsDTO>
            {
                new ProductsDTO { ProductCode = "P001", ProductName = "Producto A", Lote = "L001", Quantity = 2, Price = 10.0, Neto = 20.0 },
                new ProductsDTO { ProductCode = "P002", ProductName = "Producto B", Lote = "L002", Quantity = 1, Price = 10.0, Neto = 10.0 }
            }
            };

            // Obtener el HTML de la factura desde el servicio
            string filledHtml = print.GetInvoiceHtml(invoiceData);

            // Cargar el HTML en WebView2
            webView2.NavigateToString(filledHtml);
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (webView2.CoreWebView2 != null)
            {
                await webView2.CoreWebView2.ExecuteScriptAsync("window.print();");
            }
        }
    }
}
