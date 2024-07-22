namespace BusinessLayer.Model
{
    public class InvoiceDetailsDTO
    {
        public int InvoiceDetailsId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string Lote { get; set; }
        public int Quantity { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public decimal Neto { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
