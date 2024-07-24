using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Services;
namespace BusinessLayer.Utils
{
    public class Mapping
    {
        private readonly IInvoiceServices invoiceServices;

        public Mapping()
        {
            invoiceServices = new InvoiceServices();
        }

        public List<InvoiceViewDTO> GetInvoiceView()
        {
            var invoices = invoiceServices.GetAllInvoices();
            var invoiceViews = new List<InvoiceViewDTO>();

            foreach (var invoice in invoices)
            {
                foreach (var detail in invoice.Details)
                {
                    var invoiceView = new InvoiceViewDTO
                    {
                        InvoiceId = invoice.InvoiceID,
                        Date = invoice.Date,
                        Terms = invoice.Terms,
                        ClientId = invoice.ClientID,
                        OrderNumber = invoice.OrderNumber,
                        SellerName = invoice.SellerName,
                        Number = invoice.Number,
                        NCF = invoice.NCF,
                        DetalleId = detail.InvoiceDetailsId,
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity,
                        Price = detail.Price,
                        Lote = detail.Lote,
                        Total = detail.Total,
                        SubTotal = detail.SubTotal,
                        ProductCode = detail.ProductCode,
                        Neto = detail.Neto
                    };

                    invoiceViews.Add(invoiceView);
                }
            }

            return invoiceViews;
        }
    }
}
