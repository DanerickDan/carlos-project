using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using DataLayer.IRepository;
using DataLayer.Repositories;
using DomainLayer.Entities;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace BusinessLayer.Services
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IInvoiceRepository _repository;
        public InvoiceServices()
        {
            _repository = new InvoiceRepository();
        }

        public void AddInvoice(InvoiceDTO invoiceDTO)
        {
            List<InvoiceDetails> details = invoiceDTO.Details.Select(p => new InvoiceDetails
            {
                InvoiceId = p.InvoiceId,
                ProductId = p.ProductId,
                Lote = p.Lote,
                Quantity = p.Quantity,
                Price = p.Price,
                ProductCode = p.ProductCode,
                Neto = p.Neto,
            }).ToList();


            var invoice = new Invoice
            {
                InvoiceID = invoiceDTO.InvoiceID,
                Description = invoiceDTO.Description,
                Date = invoiceDTO.Date,
                Number = invoiceDTO.Number,
                NCF = invoiceDTO.NCF,
                Terms = invoiceDTO.Terms,
                OrderNumber = invoiceDTO.OrderNumber,
                SellerName = invoiceDTO.SellerName,
                ClientID = invoiceDTO.ClientID,
                SubTotal = invoiceDTO.SubTotal,
                Details = details,
                Total = invoiceDTO.Total
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
                OrderNumber = invoiceDTO.OrderNumber,
                SellerName = invoiceDTO.SellerName,
                ClientID = invoiceDTO.ClientID,
                SubTotal = invoiceDTO.SubTotal,
                Total = invoiceDTO.Total
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
                    OrderNumber = item.OrderNumber,
                    SellerName = item.SellerName,
                    Description = item.Description,
                    Total = item.Total,
                    SubTotal = item.SubTotal,
                    ClientID = item.ClientID,
                    Details = item.Details.Select(detail => new InvoiceDetailsDTO
                    {
                        InvoiceDetailsId = detail.InvoiceDetailsId,
                        InvoiceId = detail.InvoiceId,
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity,
                        Price = detail.Price,
                        Lote = detail.Lote,
                        ProductCode = detail.ProductCode,
                        Neto = detail.Neto
                    }).ToList()
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
                OrderNumber = invoice.OrderNumber,
                SellerName = invoice.SellerName,
                Total = invoice.Total,
                Description = invoice.Description,
                SubTotal = invoice.SubTotal,
                ClientID = invoice.ClientID,
                Details = invoice.Details.Select(detail => new InvoiceDetailsDTO
                {
                    InvoiceDetailsId = detail.InvoiceDetailsId,
                    InvoiceId = detail.InvoiceId,
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    Price = detail.Price,
                    Lote = detail.Lote,
                    ProductCode = detail.ProductCode,
                    Neto = detail.Neto
                }).ToList()
            };
            return invoiceDTO;
        }

        public List<InvoiceGridViewDTO> GetInvoicesGrid()
        {
            List<InvoiceGridViewDTO> invoices = new();
            var invoiceGrid = _repository.GetInvoicesGrid();

            foreach (var item in invoiceGrid)
            {
                InvoiceGridViewDTO invoiceGridViewDTO = new()
                {
                    InvoiceId = item.InvoiceId,
                    ClientId = item.ClientId,
                    DetailId = item.DetailId,
                    InvoiceNumber = item.InvoiceNumber,
                    ClientName = item.ClientName,
                    Date = item.Date,
                    SellerName = item.SellerName,
                    Terms = item.Terms,
                    Description = item.Description,
                    OrderNumber = item.OrderNumber,
                    Total = item.Total,
                };
                invoices.Add(invoiceGridViewDTO);
            }
            return invoices;
        }
    }
}
