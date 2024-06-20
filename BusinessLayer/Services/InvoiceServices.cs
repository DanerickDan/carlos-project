using BusinessLayer.Model;
using DataLayer.IRepository;
using DataLayer.Repositories;
using DomainLayer.Entities;

namespace BusinessLayer.Services
{
    public class InvoiceServices
    {
        private readonly IInvoiceRepository _repository;
        public InvoiceServices()
        {
            _repository = new InvoiceRepository();
        }

        public void AddInvoice(InvoiceDTO invoiceDTO)
        {
            var invoice = new Invoice
            {
                InvoiceID = invoiceDTO.InvoiceID,
                Date = invoiceDTO.Date,
                Number = invoiceDTO.Number,
                NCF = invoiceDTO.NCF,
                Terms = invoiceDTO.Terms,
                OrderNumer = invoiceDTO.OrderNumer,
                SellerName = invoiceDTO.SellerName,
                ClientID = invoiceDTO.ClientID,
            };
            _repository.AddInvoice(invoice);
        }

        public void UpdateInvoice(InvoiceDTO invoiceDTO)
        {
            var invoice = new Invoice
            {
                InvoiceID = invoiceDTO.InvoiceID,
                Date = invoiceDTO.Date,
                Number = invoiceDTO.Number,
                NCF = invoiceDTO.NCF,
                Terms = invoiceDTO.Terms,
                OrderNumer = invoiceDTO.OrderNumer,
                SellerName = invoiceDTO.SellerName,
                ClientID = invoiceDTO.ClientID,
            };
            _repository.AddInvoice(invoice);
        }

        public void DeleteInvoice(int id)
        {
            _repository.DeleteInvoice(id);
        }

        public List<InvoiceDTO> GetAllInvoices()
        {
            var invoiceDTO = new List<InvoiceDTO>();
            var invoices = _repository.GetAllInvoices();
            foreach (var item in invoices)
            {
                invoiceDTO.Add(new InvoiceDTO
                {
                    InvoiceID = item.InvoiceID,
                    Date = item.Date,
                    Number = item.Number,
                    NCF = item.NCF,
                    Terms = item.Terms,
                    OrderNumer = item.OrderNumer,
                    SellerName = item.SellerName,
                    ClientID = item.ClientID
                });
            }
            return invoiceDTO;
        }

        public InvoiceDTO GetInvoiceById(int id)
        {
            var invoice = _repository.GetInvoiceById(id);
            var invoiceDTO = new InvoiceDTO
            {
                InvoiceID = invoice.InvoiceID,
                Date = invoice.Date,
                Number = invoice.Number,
                NCF = invoice.NCF,
                Terms = invoice.Terms,
                OrderNumer = invoice.OrderNumer,
                SellerName = invoice.SellerName,
                ClientID = invoice.ClientID
            };
            return invoiceDTO;
        }
    }
}
