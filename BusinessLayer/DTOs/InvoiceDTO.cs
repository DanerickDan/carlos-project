namespace BusinessLayer.Model
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string? NCF { get; set; }
        public string Description {  get; set; }
        public string Terms { get; set; } // Crédito o Contado
        public int OrderNumber { get; set; }
        public string? SellerName { get; set; }
        public List<InvoiceDetailsDTO> Details { get; set; } = new();
        public int ClientID { get; set; }
    }
}
