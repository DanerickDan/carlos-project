﻿using DataLayer.IRepository;
using DataLayer.Repositories;

namespace BusinessLayer.Utils
{
    public class InvoiceCodeGenerator
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceCodeGenerator() 
        {
            _invoiceRepository = new InvoiceRepository();
        }

        public string InvoiceNumber()
        {
            int newCode;
            bool isUnique = false;

            do
            {
                newCode = new Random().Next(1000-9999);
                _invoiceRepository.ExistCode(newCode,"numero");
            } while (!isUnique);
            return newCode.ToString();
        }

        public string OrderNumber()
        {
            int newCode;
            bool isUnique = false;

            do
            {
                newCode = new Random().Next(1000 - 9999);
                _invoiceRepository.ExistCode(newCode, "num_pedido");
            } while (!isUnique);
            return newCode.ToString();
        }
    }
}