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
                                    LoteNcfId = reader.GetInt32(2),
                                    ClientName = reader.GetString(4),
                                    ClientCode = reader.GetInt32(5),
                                    ClientAddress = reader.GetString(6),
                                    ClientCity = reader.GetString(7),
                                    ClientPhone = reader.GetString(8),
                                    ClientRNC = reader.GetString(9),
                                    ClientEmail = reader.GetString(10),
                                    SellerName = reader.GetString(11),
                                    NCF = reader.GetString(12),
                                    InvoiceTerms = reader.GetString(13),
                                    OrderNumber = reader.GetInt32(14),
                                    InvoiceNumber = reader.GetInt32(15),
                                    Date = Convert.ToDateTime(reader.GetString(16)),
                                    SubTotal = reader.GetDouble(18),
                                    Total = reader.GetDouble(19),
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
