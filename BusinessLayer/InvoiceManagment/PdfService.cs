using PdfPig;
using PdfPig.Content;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;


namespace PresentationLayer
{
    public class PrintService
    {
        public void Print(byte[] pdfBytes, bool descargar = false)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
            File.WriteAllBytes(tempPath, pdfBytes);

            if (descargar)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Guardar PDF",
                    FileName = "Factura.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(tempPath, saveFileDialog.FileName, true);
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                }
            }

            DialogResult result = MessageBox.Show("¿Desea imprimir el documento?", "Confirmar Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PrintDocument(tempPath);
            }

            File.Delete(tempPath);
        }

        private void PrintDocument(string filePath)
        {
            using (var pdf = PdfDocument.Open(filePath))
            {
                using (PrintDocument printDocument = new PrintDocument())
                {
                    printDocument.PrintPage += (sender, e) =>
                    {
                        var page = pdf.GetPage(0);
                        using (var bitmap = new Bitmap((int)page.Width, (int)page.Height))
                        {
                            using (var graphics = Graphics.FromImage(bitmap))
                            {
                                // Aquí puedes agregar la lógica para renderizar la página PDF a un bitmap
                                // Esto depende de cómo deseas renderizar el contenido del PDF
                                // Puede ser necesario un método diferente para renderizar y dibujar el contenido en el bitmap
                            }

                            e.Graphics.DrawImage(bitmap, e.MarginBounds);
                        }
                    };

                    using (PrintDialog printDialog = new PrintDialog())
                    {
                        printDialog.Document = printDocument;

                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            printDocument.Print();
                        }
                    }
                }
            }
        }
    }
}
