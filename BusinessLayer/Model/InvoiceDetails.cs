using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class InvoiceDetails
    {
        public int DetailId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        Products Products { get; set; } = new Products();
        Invoice Invoice { get; set; } = new Invoice();
    }
}
