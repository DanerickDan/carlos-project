﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
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
        public int Quantity { get; set; }
        Categories Categories { get; set; } = new();
    }
}
