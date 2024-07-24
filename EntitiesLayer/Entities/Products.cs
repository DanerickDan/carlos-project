using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Products
    {
        public int ProductsId { get; set; }
        public string ProductName { get; set; }
        public int Code { get; set; }
        public string? Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Price {  get; set; }
        public int Lote { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int Quantity { get; set; }
        public Status Statu { get; set; }
        public Categories Category { get; set; }
    }
}
