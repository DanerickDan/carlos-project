using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;

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
                                    ClienteRNC = reader.GetInt32(6),
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
                                return new PrintView
                                {
                                    NombreCliente = reader.GetString(1),
                                    CodigoCliente = reader.GetInt32(2),
                                    ClienteDireccion = reader.GetString(3),
                                    ClienteCiudad = reader.GetString(4),
                                    ClienteTelefono = reader.GetString(5),
                                    ClienteRNC = reader.GetInt32(6),
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
                                    Neto = reader.GetDouble(20),
                                };
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetClientById: {ex.Message}", ex);
            }
            return null;
        }
    }
}
