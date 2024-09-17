namespace DomainLayer.Entities
{
    public class InvoiceGridView
    {
        public int InvoiceId { get; set; }
        public int ClientId { get; set; }
        public int DetailId { get; set; }
        public int InvoiceNumber { get; set; }
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public string SellerName { get; set; }
        public string Terms { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; }
        public double Total { get; set; }
    }
}
