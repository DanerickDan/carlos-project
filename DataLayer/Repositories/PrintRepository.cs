using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;
using System.Diagnostics;

namespace DataLayer.Repositories
{
    public class PrintRepository : IPrint
    {
        private readonly ConnectionManager connectionManager;
        private readonly IDetailInvoiceRepository _detailRepository;

        public PrintRepository()
        {
            connectionManager = new();
            _detailRepository = new DetailInvoiceRepository();
        }

        public PrintView GetInvoicePrintById(int id)
        {
            var details = _detailRepository.GetAllInvoiceDetail(id);
            List<Products> productsList = new List<Products>();
            foreach (var item in details)
            {
                Products products = new()
                {
                    Code = item.ProductCode,
                    ProductName = item.ProductName,
                    Lote = item.Lote,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    ProductNeto = item.Neto,
                }; 
                productsList.Add(products);
            }
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM Imprimir_Factura WHERE factura_id = @FacturaId";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FacturaId", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var printView = new PrintView
                                {
                                    ClientName = reader.GetString(3),
                                    ClientCode = reader.GetInt32(4),
                                    ClientAddress = reader.GetString(5),
                                    ClientCity = reader.GetString(6),
                                    ClientPhone = reader.GetString(7),
                                    ClientRNC = reader.GetString(8),
                                    ClientEmail = reader.GetString(9),
                                    SellerName = reader.GetString(10),
                                    NCF = reader.GetString(11),
                                    InvoiceTerms = reader.GetString(12),
                                    OrderNumber = reader.GetInt32(13),
                                    InvoiceNumber = reader.GetInt32(14),
                                    Date = Convert.ToDateTime(reader.GetString(15)),
                                    SubTotal = reader.GetDouble(17),
                                    Total = reader.GetDouble(18),
                                    products = productsList
                                };
                                return printView;
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetInvoiceViewByID: {ex.Message}", ex);
            }
            return null;
        }
    }
}
