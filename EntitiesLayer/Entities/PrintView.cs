﻿namespace DomainLayer.Entities
{
    public class PrintView 
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string InvoiceDescription { get; set; }
        public int ClientCode { get; set; }
        public string ClientAddress { get; set; }
        public string ClientCity { get; set; }
        public string ClientPhone { get; set; }
        public string ClientRNC { get; set; }
        public string ClientEmail { get; set; }
        public string SellerName { get; set; }
        public string NCF { get; set; }
        public string InvoiceTerms { get; set; }
        public int OrderNumber { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public List<Products> products { get; set; } = new List<Products>();
    }
}
