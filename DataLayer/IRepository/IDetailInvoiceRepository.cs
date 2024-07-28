using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IDetailInvoiceRepository
    {
        List<InvoiceDetails> GetAllInvoiceDetail();
        InvoiceDetails GetInvoiceDetailById(int id);
        void DeleteInvoice(int id);
    }
}
