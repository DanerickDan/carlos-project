using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IRepository
{
    public interface IInvoiceRepository
    {
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(int id);
        List<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int id);
    }
}
