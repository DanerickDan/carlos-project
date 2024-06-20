using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IRepository
{
    public interface IDetailInvoiceRepository
    {
        List<InvoiceDetails> GetAllInvoiceDetail();
        InvoiceDetails GetInvoiceDetailById(int id);
    }
}
