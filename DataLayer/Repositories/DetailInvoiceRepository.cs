using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;
using System.Data.SqlTypes;

namespace DataLayer.Repositories 
{
    public class DetailInvoiceRepository : IDetailInvoiceRepository
    {
        private readonly ConnectionManager connection;
        public DetailInvoiceRepository() 
        {
            connection = new();
        }

        public List<InvoiceDetails> GetAllInvoiceDetail()
        {
            var details = new List<InvoiceDetails>();
            try
            {
                connection.OpenConnection();
                using(connection.GetConnection())
                {
                    string query = "SELECT * FROM Detalle_Factura;";
                    using(var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                details.Add(new InvoiceDetails
                                {
                                    InvoiceDetailsId = reader.GetInt32(reader.GetOrdinal("DetalleId")),
                                    InvoiceId = reader.GetInt32(reader.GetOrdinal("FacturaId")),
                                    ProductId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantiadad")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Precio")),
                                    Lote = reader.GetString(reader.GetOrdinal("Lote")),
                                    Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                                    SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                                    ProductCode = reader.GetString(reader.GetOrdinal("Codigo")),
                                    Neto = reader.GetDecimal(reader.GetOrdinal("Neto"))
                                });
                            }
                        }
                        return details;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public InvoiceDetails GetInvoiceDetailById(int id)
        {
            try
            {
                connection.OpenConnection();
                using (connection.GetConnection())
                {
                    string query = "SELECT * FROM Detalle_Factura WHEREN detalle_id = @Id;";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new InvoiceDetails
                                {
                                    InvoiceDetailsId = reader.GetInt32(reader.GetOrdinal("DetalleId")),
                                    InvoiceId = reader.GetInt32(reader.GetOrdinal("FacturaId")),
                                    ProductId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantiadad")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Precio")),
                                    Lote = reader.GetString(reader.GetOrdinal("Lote")),
                                    Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                                    SubTotal = reader.GetDecimal(reader.GetOrdinal("SubTotal")),
                                    ProductCode = reader.GetString(reader.GetOrdinal("Codigo")),
                                    Neto = reader.GetDecimal(reader.GetOrdinal("Neto"))
                                };
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
