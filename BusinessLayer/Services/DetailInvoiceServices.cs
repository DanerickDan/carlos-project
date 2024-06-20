using BusinessLayer.Model;
using DataLayer.IRepository;
using DataLayer.Repositories;

namespace BusinessLayer.Services
{
    public class DetailInvoiceServices
    {
        private readonly IDetailInvoiceRepository _repository;
        public DetailInvoiceServices() 
        {
            _repository = new DetailInvoiceRepository();
        }

        public List<InvoiceDetailsDTO> GetAllInvoiceDetail()
        {
            var invoiceDetailsDTO = new List<InvoiceDetailsDTO>();
            var invoiceDetails = _repository.GetAllInvoiceDetail();

            foreach (var item in invoiceDetails)
            {
                invoiceDetailsDTO.Add(new InvoiceDetailsDTO
                {
                    InvoiceDetailsId = item.InvoiceDetailsId,
                    InvoiceId = item.InvoiceId,
                    ProductId = item.ProductId,
                    Lote = item.Lote,
                    Quantity = item.Quantity,
                    ProductCode = item.ProductCode,
                    Price = item.Price,
                    Neto = item.Neto,
                    SubTotal = item.SubTotal,
                    Total = item.Total,
                    
                });
            }
            return invoiceDetailsDTO;

        }

        public InvoiceDetailsDTO GetInvoiceDetailById(int id)
        {
            var invoiceDetails = _repository.GetInvoiceDetailById(id);

            var invoiceDetailsDTO = new InvoiceDetailsDTO
            {
                InvoiceDetailsId = invoiceDetails.InvoiceDetailsId,
                InvoiceId = invoiceDetails.InvoiceId,
                ProductId = invoiceDetails.ProductId,
                Lote = invoiceDetails.Lote,
                Quantity = invoiceDetails.Quantity,
                ProductCode = invoiceDetails.ProductCode,
                Price = invoiceDetails.Price,
                Neto = invoiceDetails.Neto,
                SubTotal = invoiceDetails.SubTotal,
                Total = invoiceDetails.Total,
            };
            return invoiceDetailsDTO;
        }
    }
}
