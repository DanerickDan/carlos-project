using BusinessLayer.DTOs;
using BusinessLayer.Model;

namespace BusinessLayer.InvoiceManagment
{
    public class Print
    {
        private readonly string templatePath;

        public Print(string templatePath)
        {
            this.templatePath = templatePath;
        }

        public string GetInvoiceHtml(InvoiceViewDTO invoiceData)
        {
            // Lee la plantilla HTML
            string template = File.ReadAllText(templatePath);

            // Reemplaza los marcadores de posición con los datos reales
            string filledTemplate = template
                .Replace("{{ClientName}}", invoiceData.ClientName)
                .Replace("{{ClientCode}}", invoiceData.ClientCode)
                .Replace("{{ClientAddress}}", invoiceData.ClientAddress)
                .Replace("{{ClientCity}}", invoiceData.ClientCity)
                .Replace("{{ClientPhone}}", invoiceData.ClientPhone)
                .Replace("{{ClientRNC}}", invoiceData.ClientRNC)
                .Replace("{{SellerName}}", invoiceData.SellerName)
                .Replace("{{NCF}}", invoiceData.NCF)
                .Replace("{{Terms}}", invoiceData.Terms)
                .Replace("{{OrderNumber}}", invoiceData.OrderNumber)
                .Replace("{{InvoiceNumber}}", invoiceData.InvoiceNumber)
                .Replace("{{Date}}", invoiceData.Date.ToString("dd/MM/yyyy"))
                .Replace("{{SubTotal}}", invoiceData.SubTotal.ToString("F2"))
                .Replace("{{Total}}", invoiceData.Total.ToString("F2"));

            // Reemplaza los datos de los productos
            string productRows = "";
            foreach (var product in invoiceData.Products)
            {
                productRows += "<tr>";
                productRows += $"<th scope='row'>{product.ProductCode}</th>";
                productRows += $"<td>{product.ProductName}</td>";
                productRows += $"<td>{product.Lote}</td>";
                productRows += $"<td>{product.Quantity}</td>";
                productRows += $"<td>${product.Price:F2}</td>";
                productRows += $"<td>{product.Neto:F2}</td>";
                productRows += "</tr>";
            }
            filledTemplate = filledTemplate.Replace("{{ProductRows}}", productRows);

            return filledTemplate;
        }
    }
}
