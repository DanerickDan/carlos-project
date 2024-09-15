using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BusinessLayer.InvoiceManagment
{
    public class PdfService
    {
        public async Task<byte[]> GeneratePdfAsync(string htmlContent)
        {
            //// Descargar Chromium si es necesario
            //await new BrowserFetcher().DownloadAsync();

            // Iniciar el navegador
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using var page = await browser.NewPageAsync();

            // Cargar el contenido HTML
            await page.SetContentAsync(htmlContent);

            // Generar el PDF con los estilos aplicados
            var pdfBytes = await page.PdfDataAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true // Esto asegura que los estilos CSS se rendericen correctamente
            });

            return pdfBytes;
        }
    }
}
