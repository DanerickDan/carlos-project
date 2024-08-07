using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;


namespace BusinessLayer.InvoiceManagment
{
    public class PdfService
    {
        private readonly IConverter _converter;

        public PdfService()
        {
            var context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));
            _converter = new SynchronizedConverter(new PdfTools());
        }

        public byte[] GeneratePdf(string htmlContent)
        {
            var document = new HtmlToPdfDocument
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
            },
                Objects = {
                new ObjectSettings {
                    PagesCount = true,
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            return _converter.Convert(document);
        }
    }
}
