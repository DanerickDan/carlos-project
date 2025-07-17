namespace DomainLayer.Entities
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string? NCF { get; set; }
        public int NcfLoteId { get; set; }
        public string Description { get; set; }
        public string Terms { get; set; } // Crédito o Contado
        public int OrderNumber { get; set; }
        public string? SellerName { get; set; }
        public int ClientID { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public List<InvoiceDetails> Details { get; set; } = new();
        Client Client { get; set; } = new();
    }
}
