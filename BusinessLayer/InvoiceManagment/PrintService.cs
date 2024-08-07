
using BusinessLayer.DTOs;

namespace BusinessLayer.InvoiceManagment
{
    public class PrintService
    {
        public void Print(byte[] pdfBytes)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
            File.WriteAllBytes(tempPath, pdfBytes);

            using (PrintDocument printDocument = new PrintDocument())
            {
                printDocument.PrintPage += (sender, e) =>
                {
                    System.Drawing.Image image = System.Drawing.Image.FromFile(tempPath);
                    Point loc = new Point(0, 0);
                    e.Graphics.DrawImage(image, loc);
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

            File.Delete(tempPath);
        }

        public string FillTemplate()
        {

        }
    }
}
