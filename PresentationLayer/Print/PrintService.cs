using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using DataLayer.Repositories;
using System.Diagnostics;

namespace PresentationLayer.Print
{
    public class PrintService : IPrintService
    {
        private readonly PrintRepository _printRepository;
        public PrintService()
        {
            _printRepository = new PrintRepository();
        }
        public async Task PrintAsync(byte[] pdfBytes, bool download)
        {
            // Guardar temporalmente el archivo PDF
            var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
            await File.WriteAllBytesAsync(tempPath, pdfBytes);

            if (download == true)
            {
                // Mostrar diálogo de guardar
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

            // Preguntar si desea imprimir
            DialogResult result = MessageBox.Show("¿Desea imprimir el documento?", "Confirmar Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Enviar el archivo a la impresora
                PrintDocument(pdfBytes);
            }

            // Eliminar el archivo temporal
            File.Delete(tempPath);
        }




        public void PrintDocument(byte[] pdfBytes)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
            File.WriteAllBytes(tempPath, pdfBytes);

            // Mostrar el cuadro de diálogo para confirmar la impresión
            // Mostrar el diálogo de impresión para seleccionar la impresora
            using (PrintDialog printDialog = new PrintDialog())
            {
                // Configurar el diálogo de impresión
                printDialog.AllowSomePages = true;
                printDialog.ShowHelp = true;

                // Mostrar el diálogo de impresión
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Crear un proceso para imprimir el archivo PDF
                    var printProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = tempPath,
                            Verb = "print",
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        }
                    };
                    printProcess.Start();
                    printProcess.WaitForExit();
                }
            }


            // Eliminar el archivo temporal después de la impresión
            File.Delete(tempPath);
        }





        //public void Print(byte[] pdfBytes, bool descargar)
        //{
        //    var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
        //    File.WriteAllBytes(tempPath, pdfBytes);

        //    if (descargar == true)
        //    {
        //        // Descargar el PDF para que el usuario lo vea antes de imprimir
        //        SaveFileDialog saveFileDialog = new SaveFileDialog
        //        {
        //            Filter = "PDF files (*.pdf)|*.pdf",
        //            Title = "Guardar PDF",
        //            FileName = "Factura.pdf"
        //        };

        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            File.Copy(tempPath, saveFileDialog.FileName, true);

        //            // Abrir el PDF para que el usuario lo vea
        //            Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
        //        }
        //    }

        //    // Preguntar al usuario si desea proceder con la impresión
        //    DialogResult result = MessageBox.Show("¿Desea imprimir el documento?", "Confirmar Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (result == DialogResult.Yes)
        //    {
        //        using (PdfDocument document = PdfReader.Open(tempPath, PdfDocumentOpenMode.Import))
        //        {
        //            using (PrintDocument printDocument = new PrintDocument())
        //            {
        //                printDocument.PrintPage += (sender, e) =>
        //                {
        //                    XGraphics gfx = XGraphics.FromPdfPage(document.Pages[0]);
        //                    gfx.DrawImage(XImage.FromFile(tempPath), 0, 0);
        //                };

        //                using (PrintDialog printDialog = new PrintDialog())
        //                {
        //                    printDialog.Document = printDocument;

        //                    if (printDialog.ShowDialog() == DialogResult.OK)
        //                    {
        //                        printDocument.Print();
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    File.Delete(tempPath);
        //}


        public PrintViewDTO GetInvoicePrintById(int id)
        {
            try
            {
                // Obtener los datos de la factura utilizando el repositorio
                var data = _printRepository.GetInvoicePrintById(id);

                // Verificar si los datos de la factura son nulos
                if (data == null)
                {
                    throw new Exception($"Invoice with ID {id} not found.");
                }

                // Mapear los datos obtenidos a un DTO para la impresión
                PrintViewDTO printViewDTO = new PrintViewDTO
                {
                    LoteNcfId = data.LoteNcfId,
                    ClientName = data.ClientName ?? string.Empty,
                    ClientCode = data.ClientCode,
                    ClientAddress = data.ClientAddress ?? string.Empty,
                    ClientCity = data.ClientCity ?? string.Empty,
                    ClientPhone = data.ClientPhone ?? string.Empty,
                    ClientRNC = data.ClientRNC ?? string.Empty,
                    ClientEmail = data.ClientEmail ?? string.Empty,
                    SellerName = data.SellerName ?? string.Empty,
                    NCF = data.NCF ?? string.Empty,
                    InvoiceTerms = data.InvoiceTerms ?? string.Empty,
                    OrderNumber = data.OrderNumber,
                    InvoiceNumber = data.InvoiceNumber,
                    Date = data.Date,
                    SubTotal = data.SubTotal,
                    Total = data.Total,
                    products = data.products?.Select(p => new ProductsDTO
                    {
                        Code = p.Code,
                        ProductName = p.ProductName ?? string.Empty,
                        Lote = p.Lote,
                        Quantity = p.Quantity,
                        Price = p.Price,
                        ProductNeto = p.ProductNeto
                    }).ToList() ?? new List<ProductsDTO>()
                };

                return printViewDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message} y  Stack Trace: {ex.StackTrace}", ex);
            }
        }

    }
}
