﻿using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IInvoiceRepository
    {
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(int id);
        List<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int id);
        int GetMaxCode(string column);
        IEnumerable<InvoiceGridView> GetInvoicesGrid();
    }
}
