using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IInvoiceRepository
    {
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(int id);
        List<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int id);
        bool ExistCode(int code, string type);
    }
}
