﻿namespace BusinessLayer.Model
{
    public class InvoiceDetailsDTO
    {
        public int InvoiceDetailsId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Lote { get; set; }
        public int Quantity { get; set; }
        public int ProductCode { get; set; }
        public double Price { get; set; }
        public double Neto { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
    }
}
