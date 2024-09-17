using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IDetailInvoiceRepository
    {
        List<InvoiceDetails> GetAllInvoiceDetail(int id);
        void DeleteInvoice(int id);
    }
}
