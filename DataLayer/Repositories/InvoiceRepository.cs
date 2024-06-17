using DataLayer.Connection;
using DomainLayer.Entities;
using System.Data.SQLite;
using System.Transactions;

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
                string query =
                        "INSERT INTO Facturas (Fecha, NumeroFactura, NCF, Terminos, NumeroPedido, NombreVendedor, ClienteID, Subtotal, ITBIS, Total) " +
                        "VALUES (@Fecha, @NumeroFactura, @NCF, @Terminos, @NumeroPedido, @NombreVendedor, @ClienteID, @Subtotal, @ITBIS, @Total); " +
                        "SELECT last_insert_rowid();";
                using (var command = new SQLiteCommand(query, connection.GetConnection()))
                {
                    var transaction = command.Connection.BeginTransaction();
                    command.Parameters.AddWithValue("@Fecha", invoice.Fecha);
                    command.Parameters.AddWithValue("@NumeroFactura", invoice.NumeroFactura);
                    command.Parameters.AddWithValue("@NCF", invoice.NCF);
                    command.Parameters.AddWithValue("@Terminos", invoice.Terminos);
                    command.Parameters.AddWithValue("@NumeroPedido", invoice.NumeroPedido);
                    command.Parameters.AddWithValue("@NombreVendedor", invoice.NombreVendedor);
                    command.Parameters.AddWithValue("@ClienteID", invoice.ClienteID);
                    command.Parameters.AddWithValue("@Subtotal", invoice.Subtotal);
                    command.Parameters.AddWithValue("@ITBIS", invoice.ITBIS);
                    command.Parameters.AddWithValue("@Total", invoice.Total);

                    invoice.FacturaID = Convert.ToInt32(command.ExecuteScalar());
                }

                foreach (var detalle in factura.Detalles)
                {
                    using (var command = new SQLiteCommand(
                        "INSERT INTO FacturaDetalles (FacturaID, ProductoID, Lote, Cantidad, Precio, Neto) " +
                        "VALUES (@FacturaID, @ProductoID, @Lote, @Cantidad, @Precio, @Neto)", connection))
                    {
                        command.Parameters.AddWithValue("@FacturaID", factura.FacturaID);
                        command.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                        command.Parameters.AddWithValue("@Lote", detalle.Lote);
                        command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        command.Parameters.AddWithValue("@Precio", detalle.Precio);
                        command.Parameters.AddWithValue("@Neto", detalle.Neto);

                        command.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
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
                using (connection.GetConnection())
                {
                    string query = "UPDATE Facturas SET fecha = @Fecha, terminos = @Terminos,cliente_id = @ClienteId" +
                                    "num_pedido = @NumPedido, vendedor = @Vendedor, NCF = @ncf" +
                                    "WHERE factura_id = @FacturaID";
                    var command = new SQLiteCommand(query, connection.GetConnection());
                    using (var transaction = command.Transaction)
                    {
                        using (command)
                        {
                            command.Parameters.AddWithValue("@FacturaID", invoice.InvoiceID);
                            command.Parameters.AddWithValue("@Fecha", invoice.Date);
                            command.Parameters.AddWithValue("@NumeroFactura", invoice.Number);
                            command.Parameters.AddWithValue("@NCF", invoice.NCF);
                            command.Parameters.AddWithValue("@Terminos", invoice.Terms);
                            command.Parameters.AddWithValue("@NumeroPedido", invoice.OrderNumer);
                            command.Parameters.AddWithValue("@NombreVendedor", invoice.SellerName);
                            command.Parameters.AddWithValue("@ClienteID", invoice.ClientID);
                            command.Parameters.AddWithValue("@Subtotal", invoice.NCF);

                            command.ExecuteNonQuery();
                        }

                        using (var command2 = new SQLiteCommand("DELETE FROM Detalle_Factura WHERE factura_id = @FacturaID", connection.GetConnection()))
                        {
                            command2.Parameters.AddWithValue("@FacturaID", invoice.InvoiceID);
                            command2.ExecuteNonQuery();
                        }

                        foreach (var details in invoice.Details)
                        {
                            using (var command3 = new SQLiteCommand(
                                "INSERT INTO Detalles_Factura (factura_id, producto_id, cantidad, precio_unitario, lote, total) " +
                                "sub_total, codigo, neto" +
                                "VALUES (@FacturaID, @ProductoID, @Cantidad, @PrecioUnitario, @Lote, @Total, @SubTotal, @Codigo, @Neto)", connection.GetConnection()))
                            {
                                command3.Parameters.AddWithValue("@FacturaId", details.InvoiceId);
                                command3.Parameters.AddWithValue("@ProductoId", details.ProductId);
                                command3.Parameters.AddWithValue("@Cantidad", details.Quantity);
                                command3.Parameters.AddWithValue("@PrecioUnitario", details.Price);
                                command3.Parameters.AddWithValue("@Lote", details.Lote);
                                command3.Parameters.AddWithValue("@Total", details.Total);
                                command3.Parameters.AddWithValue("@SubTotal", details.SubTotal);
                                command3.Parameters.AddWithValue("@Codigo", details.ProductCode);
                                command3.Parameters.AddWithValue("@Neto", details.Neto);


                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        connection.CloseConnection();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteInvoice(int id)
        {
            try
            {
                connection.OpenConnection();

                using (connection.GetConnection())
                {
                    string query = "DELETE FROM Facturas WHERE facturas_id = @Id";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Id", id);
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

        public List<Invoice> GetAllInvoice()
        {
            var invoices = new List<Invoice>();
            try
            {
                connection.OpenConnection();
                string query = "SELECT * FROM Facturas";
                using (connection.GetConnection())
                {
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                invoices.Add(new Invoice
                                {
                                    InvoiceID = reader.GetInt32(0),
                                    Date = reader.GetDateTime(1),
                                    Terms = reader.GetString(2),
                                    ClientID = reader.GetInt32(3),
                                    OrderNumer = reader.GetInt32(4),
                                    SellerName = reader.GetString(5),
                                    NCF = reader.GetString(6)
                                });
                            }
                        }
                    }
                    connection.CloseConnection();
                }
                return invoices;
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
                                    OrderNumer = reader.GetInt32(4),
                                    SellerName = reader.GetString(5),
                                    NCF = reader.GetString(6)
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
