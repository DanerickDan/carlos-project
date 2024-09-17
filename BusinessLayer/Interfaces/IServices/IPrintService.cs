using BusinessLayer.DTOs;

namespace BusinessLayer.Interfaces.IServices
{
    public interface IPrintService
    {
        PrintViewDTO GetInvoicePrintById(int id);

    }
}
