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

        public async void InitializeWebView2()
        {
            this.Controls.Add(webView2);
            await webView2.EnsureCoreWebView2Async(null);

            // data

            // Obtener el HTML de la factura desde el servicio
            string filledHtml = print.GetInvoiceHtml(invoiceData);

            // Cargar el HTML en WebView2
            webView2.NavigateToString(filledHtml);
        }

        public async void btnPrint_Click()
        {
            if (webView2.CoreWebView2 != null)
            {
                await webView2.CoreWebView2.ExecuteScriptAsync("window.print();");
            }
        }
    }
}
