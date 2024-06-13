using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class InvoiceDetailsDTO
    {
        public int DetailId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        ProductsDTO Products { get; set; } = new ProductsDTO();
        InvoiceDTO Invoice { get; set; } = new InvoiceDTO();
    }
}
