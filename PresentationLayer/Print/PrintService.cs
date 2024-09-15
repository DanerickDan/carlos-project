using System.Diagnostics;

namespace PresentationLayer.Print
{
    public class PrintService 
    {
        public async Task PrintAsync(byte[] pdfBytes)
        {
            // Guardar temporalmente el archivo PDF
            var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
            await File.WriteAllBytesAsync(tempPath, pdfBytes);

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
            // Convertir el byte array del PDF a un documento imprimible
            var tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
            File.WriteAllBytes(tempPath, pdfBytes);

            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = tempPath,
                    Verb = "print",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                process.Start();
            }
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


        //public PrintViewDTO GetInvoicePrintById(int id)
        //{
        //    try
        //    {
        //        // Obtener los datos de la factura utilizando el repositorio
        //        var data = printRepository.GetInvoicePrintById(id);

        //        // Verificar si los datos de la factura son nulos
        //        if (data == null)
        //        {
        //            throw new Exception($"Invoice with ID {id} not found.");
        //        }

        //        // Mapear los datos obtenidos a un DTO para la impresión
        //        PrintViewDTO printViewDTO = new PrintViewDTO
        //        {
        //            NombreCliente = data.NombreCliente ?? string.Empty,
        //            CodigoCliente = data.CodigoCliente,
        //            ClienteDireccion = data.ClienteDireccion ?? string.Empty,
        //            ClienteCiudad = data.ClienteCiudad ?? string.Empty,
        //            ClienteTelefono = data.ClienteTelefono ?? string.Empty,
        //            ClienteRNC = data.ClienteRNC ?? string.Empty,
        //            Vendedor = data.Vendedor ?? string.Empty,
        //            NCF = data.NCF ?? string.Empty,
        //            Terminos = data.Terminos ?? string.Empty,
        //            NumeroPedido = data.NumeroPedido,
        //            NumeroFactura = data.NumeroFactura,
        //            Fecha = data.Fecha,
        //            SubTotal = data.SubTotal,
        //            Total = data.Total,
        //            CodigoProducto = data.CodigoProducto,
        //            NombreProducto = data.NombreProducto ?? string.Empty,
        //            LoteProducto = data.LoteProducto,
        //            Cantidad = data.Cantidad,
        //            PrecioUnitario = data.PrecioUnitario,
        //            Neto = data.Neto,
        //            products = data.products?.Select(p => new ProductsDTO
        //            {
        //                Code = p.Code,
        //                ProductName = p.ProductName ?? string.Empty,
        //                Lote = p.Lote,
        //                Quantity = p.Quantity,
        //                Price = p.Price,
        //                ProductNeto = p.ProductNeto
        //            }).ToList() ?? new List<ProductsDTO>()
        //        };

        //        return printViewDTO;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de excepciones: puedes registrar el error o hacer algo específico según el tipo de error
        //        // Por ejemplo, podrías utilizar un logger aquí si tienes uno configurado
        //        throw new Exception($"Exception: {ex.Message} y  Stack Trace: {ex.StackTrace}", ex);
        //    }
        //}


        //public List<PrintViewDTO> GetAllInvoicePrint()
        //{
        //    return new List<PrintViewDTO>();
        //}
    }
}
