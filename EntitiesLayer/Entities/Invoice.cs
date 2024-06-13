using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string? Tearms { get; set; }
        public int OrderNumber { get; set; }
        public string? Seller {  get; set; }

        Client Client { get; set; } = new();
    }
}
