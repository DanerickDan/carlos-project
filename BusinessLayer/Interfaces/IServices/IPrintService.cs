using BusinessLayer.DTOs;


namespace BusinessLayer.Interfaces.IServices
{
    public interface IPrintService
    {
        public PrintViewDTO GetInvoicePrintById(int id);
        public List<PrintViewDTO> GetAllInvoicePrint();
    }
}
