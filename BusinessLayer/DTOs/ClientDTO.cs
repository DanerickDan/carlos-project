using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Fax { get; set; }
        public string? Rnc { get; set; }
        public int Code { get; set; }
    }
}
