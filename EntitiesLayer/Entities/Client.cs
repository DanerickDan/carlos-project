using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Client
    {
        public int ClienstId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string? Fax { get; set; }
        public string? Rnc { get; set; }
    }
}
