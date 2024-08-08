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

        public PrintRepository()
        {
            connectionManager = new();
        }

        public List<PrintView> GetAllInvoicePrint()
        {
            var printView = new List<PrintView>();
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM Imprimir_Factura";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                printView.Add(new PrintView
                                {
                                    NombreCliente = reader.GetString(1),
                                    CodigoCliente = reader.GetInt32(2),
                                    ClienteDireccion = reader.GetString(3),
                                    ClienteCiudad = reader.GetString(4),
                                    ClienteTelefono = reader.GetString(5),
                                    ClienteRNC = reader.GetString(6),
                                    Vendedor = reader.GetString(7),
                                    NCF = reader.GetString(8),
                                    Terminos = reader.GetString(9),
                                    NumeroPedido = reader.GetInt32(10),
                                    NumeroFactura = reader.GetInt32(11),
                                    Fecha = Convert.ToDateTime(reader.GetString(12)), 
                                    SubTotal = reader.GetDouble(13),
                                    Total = reader.GetDouble(14),
                                    CodigoProducto = reader.GetInt32(15),
                                    NombreProducto = reader.GetString(16),
                                    LoteProducto = reader.GetInt32(17),
                                    Cantidad = reader.GetInt32(18),
                                    PrecioUnitario = reader.GetDouble(19),
                                    Neto = reader.GetDouble(20)
                                });
                            }
                        }

                    }
                }
                return printView;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllInvoices: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public PrintView GetInvoicePrintById(int id)
        {
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
                                var printView =  new PrintView
                                {
                                    NombreCliente = reader.GetString(3),
                                    CodigoCliente = reader.GetInt32(4),
                                    ClienteDireccion = reader.GetString(5),
                                    ClienteCiudad = reader.GetString(6),
                                    ClienteTelefono = reader.GetString(7),
                                    ClienteRNC = reader.GetString(8),
                                    Vendedor = reader.GetString(9),
                                    NCF = reader.GetString(10),
                                    Terminos = reader.GetString(11),
                                    NumeroPedido = reader.GetInt32(12),
                                    NumeroFactura = reader.GetInt32(13),
                                    Fecha = Convert.ToDateTime(reader.GetString(14)),
                                    SubTotal = reader.GetDouble(16),
                                    Total = reader.GetDouble(17),     
                                };
                                var products = new Products()
                                {
                                    Code = reader.GetInt32(18),
                                    ProductName = reader.GetString(19),
                                    Lote = reader.GetInt32(20),
                                    Quantity = reader.GetInt32(21),
                                    Price = reader.GetDouble(22),
                                    ProductNeto = reader.GetInt32(21) * reader.GetDouble(22),
                                };
                                printView.products.Add(products);
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
