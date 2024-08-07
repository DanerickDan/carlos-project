using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IPrint
    {
        List<PrintView> GetAllInvoicePrint();
        PrintView GetInvoicePrintById(int id);
    }
}
