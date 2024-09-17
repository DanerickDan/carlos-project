using PuppeteerSharp;
using PuppeteerSharp.Media;


namespace BusinessLayer.InvoiceManagment
{
    public class PdfService
    {
        public async Task<byte[]> GeneratePdfAsync(string htmlContent)
        {
            // Inicializa BrowserFetcher y descarga la última versión de Chromium
            //var browserFetcher = new BrowserFetcher();
            //await browserFetcher.DownloadAsync();

            var launchOptions = new LaunchOptions
            {
                Headless = true // Ejecutar en modo sin interfaz gráfica
            };

            try
            {
                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", // Cambia esta ruta según el navegador del cliente
                    Headless = true
                });
                var page = await browser.NewPageAsync();

                // Cargar el contenido HTML
                await page.SetContentAsync(htmlContent);

                // Generar el PDF
                var pdfStream = await page.PdfStreamAsync(new PdfOptions
                {
                    Format = PaperFormat.A4,
                    PrintBackground = true // Incluye los estilos CSS en el PDF
                });

                // Convertir el Stream a un array de bytes
                using (var memoryStream = new MemoryStream())
                {
                    await pdfStream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error generando el PDF: {ex.Message}");
                throw;
            }
        }
    }
}
