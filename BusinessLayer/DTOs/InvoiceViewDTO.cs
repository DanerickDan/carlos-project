namespace BusinessLayer.DTOs
{
    public class InvoiceViewDTO
    {
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string Terms { get; set; }
        public int ClientId { get; set; }
        public int OrderNumber { get; set; }
        public string SellerName { get; set; }
        public int Number { get; set; }
        public string NCF { get; set; }
        public int DetalleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Lote { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public string ProductCode { get; set; }
        public double Neto { get; set; }

    }
}
