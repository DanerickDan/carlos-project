using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IPrint
    {
        PrintView GetInvoicePrintById(int id);
    }
}
