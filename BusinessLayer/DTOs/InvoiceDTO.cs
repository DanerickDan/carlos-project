namespace BusinessLayer.Model
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string? Number { get; set; }
        public string? NCF { get; set; }
        public string Terms { get; set; } // Crédito o Contado
        public int OrderNumer { get; set; }
        public string? SellerName { get; set; }
        public int ClientID { get; set; }
    }
}
