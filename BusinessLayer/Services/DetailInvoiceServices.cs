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
            var invoiceDetails = _repository.GetAllInvoiceDetail(1);

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
                    
                });
            }
            return invoiceDetailsDTO;

        }

    }
}
