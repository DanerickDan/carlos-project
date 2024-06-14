using DataLayer.Connection;
using DomainLayer.Entities;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class InvoiceRepository
    {
        private readonly ConnectionManager connection;
        public InvoiceRepository() 
        {
            connection = new();
        }
        
        public void AddInvoice(Invoice invoice)
        {
            try
            {
                connection.OpenConnection();
                string query = "INSERT INTO Facturas (fecha,terminos,cliente_id, num_pedido, vendedor, NCF," +
                        " Total, lote, cantidad, subtotal) " +
                        "VALUES (@Fecha,@Terminos, @ClienteId, @NumPedido, @Vendedor, @NCFs); ";
                using(connection.GetConnection())
                {
                    using(var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Fecha", invoice.Date);
                        command.Parameters.AddWithValue("@Terminos", invoice.Terms);
                        command.Parameters.AddWithValue("@ClienteId", invoice.ClientID);
                        command.Parameters.AddWithValue("@NumPedido", invoice.OrderNumer);
                        command.Parameters.AddWithValue("Vendedor", invoice.SellerName);
                        command.Parameters.AddWithValue("@NFC", invoice.NCF);
                        command.ExecuteNonQuery();
                    }
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateInvoice(Invoice invoice) 
        {
            try
            {
                connection.OpenConnection();
                string query = "UPDATE Facturas SET fecha = @Fecha, terminos = @Terminos, cliente_id = @ClienteId," +
                    "num_pedido = @NumPedido, vendedor = @Vendedor, NCF, @ncf WHERE factura_id = @FacturaId";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteInvoice(int id) 
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Invoice> GetAllInvoice()
        {
            var invoices = new List<Invoice>();
            try
            {
                connection.OpenConnection();
                string query = "SELECT * FROM Facturas";
                using (connection.GetConnection())
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public Invoice GetInvoiceById(int id) 
        {
            try
            {
                using (connection.GetConnection())
                {
                    connection.OpenConnection();
                    string query = "SELECT * FROM Facturas WHERE factura_id = @FacturaID";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@FacturaID", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Invoice
                                {
                                    InvoiceID = reader.GetInt32(0),
                                    Date = reader.GetDateTime(1),
                                    Terms = reader.GetString(2),
                                    ClientID = reader.GetInt32(3),
                                    OrderNumer = reader.GetString(4),
                                    SellerName = reader.GetString(5),
                                    NCF = reader.GetString(6),
                                    Total = reader.GetInt32(7),
                                };
                            }
                        }
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
