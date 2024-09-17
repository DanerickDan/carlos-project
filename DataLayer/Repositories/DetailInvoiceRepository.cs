using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;
using System.Data.SqlTypes;

namespace DataLayer.Repositories
{
    public class DetailInvoiceRepository : IDetailInvoiceRepository
    {
        private readonly ConnectionManager connectionManager;
        public DetailInvoiceRepository()
        {
            connectionManager = new();
        }

        public void DeleteInvoice(int id)
        {
            try
            {

                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "DELETE FROM Detalle_Factura WHERE detalle_id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public List<InvoiceDetails> GetAllInvoiceDetail(int id)
        {
            List<InvoiceDetails> detailsList = new List<InvoiceDetails>();
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM DetalleFactura WHERE factura_id = @Id;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                InvoiceDetails details = new InvoiceDetails
                                {
                                    InvoiceId = reader.GetInt32(0),
                                    Quantity = reader.GetInt32(1),
                                    Price = reader.GetDouble(2),
                                    Lote = reader.GetInt32(3),
                                    ProductCode = reader.GetString(4),
                                    Neto = reader.GetDouble(5),
                                    ProductName = reader.GetString(6)
                                };
                                detailsList.Add(details);
                            }
                        }
                        return detailsList;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
