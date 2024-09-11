using System;
using System.IO;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace BusinessLayer.InvoiceManagment
{
    public class PdfService
    {
        public byte[] GeneratePdf(string htmlContent)
        {
            // Usa PdfPig para generar el PDF a partir del HTML
            var pdfBytes = ConvertHtmlToPdf(htmlContent); // Implementa este método según tu necesidad
            return pdfBytes;
        }

        private byte[] ConvertHtmlToPdf(string htmlContent)
        {
            // Implementa aquí la conversión de HTML a PDF usando PdfPig o una librería compatible
            throw new NotImplementedException("Implementa la conversión de HTML a PDF aquí.");
        }
    }
}
