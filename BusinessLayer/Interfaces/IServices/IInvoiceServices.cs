using BusinessLayer.DTOs;
using BusinessLayer.Model;

namespace BusinessLayer.Interfaces.IServices
{
    public interface IInvoiceServices
    {
        public void AddInvoice(InvoiceDTO invoiceDTO);
        public void UpdateInvoice(InvoiceDTO invoiceDTO);
        public void DeleteInvoice(int id);
        public List<InvoiceDTO> GetAllInvoices();
        public InvoiceDTO GetInvoiceById(int id);
        List<InvoiceGridViewDTO> GetInvoicesGrid();
    }
}
