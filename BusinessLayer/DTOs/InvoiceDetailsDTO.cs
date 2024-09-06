namespace BusinessLayer.Model
{
    public class InvoiceDetailsDTO
    {
        public int InvoiceDetailsId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Lote { get; set; }
        public int Quantity { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Neto { get; set; }
        
    }
}
