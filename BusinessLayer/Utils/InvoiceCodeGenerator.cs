using DataLayer.IRepository;
using DataLayer.Repositories;

namespace BusinessLayer.Utils
{
    public class InvoiceCodeGenerator
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceCodeGenerator()
        {
            _invoiceRepository = new InvoiceRepository();
        }

        public string GenerateInvoiceNumber()
        {
            int lastNumber = _invoiceRepository.GetMaxCode("numero");
            int nextNumber = lastNumber + 1;
            return nextNumber.ToString("D4"); // D4 = 4 dígitos con ceros a la izquierda
        }

        public string GenerateOrderNumber()
        {
            int lastNumber = _invoiceRepository.GetMaxCode("num_pedido");
            int nextNumber = lastNumber + 1;
            return nextNumber.ToString("D4");
        }
    }
}
