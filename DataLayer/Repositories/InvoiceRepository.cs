using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
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
                // Transacion para si ocurre algun error darle rollback 
                var connectionT = new SQLiteConnection("Data Source= ./bd_sqlite.db");
                connectionT.Open();
                string query =
                        "INSERT INTO Facturas (fecha, terminos, cliente_id, num_pedido, vendedor, NCF) " +
                        "VALUES (@Fecha, @Terminos, @ClienteId, @NumPedido, @Vendedor, @NCF); " +
                        "SELECT last_insert_rowid();";
                using (var transaction = connectionT.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SQLiteCommand(query, connectionT, transaction))
                        {
                            command.Parameters.AddWithValue("@Fecha", invoice.Date);
                            command.Parameters.AddWithValue("@Terminos", invoice.Terms);
                            command.Parameters.AddWithValue("@ClienteId", invoice.ClientID);
                            command.Parameters.AddWithValue("@NumPedido", invoice.OrderNumer);
                            command.Parameters.AddWithValue("@Vendedor", invoice.SellerName);
                            command.Parameters.AddWithValue("@NCF", invoice.NCF);

                            invoice.InvoiceID = Convert.ToInt32(command.ExecuteScalar());
                        }

                        foreach (var detail in invoice.Details)
                        {
                            using (var command = new SQLiteCommand(
                                "INSERT INTO Detalle_Factura (factura_id, producto_id, cantidad, precio_unitario, lote, total, " +
                                "sub_total, codigo, neto)" +
                                "VALUES (@FacturaID, @ProductoID, @Cantidad, @PrecioUnitario, @Lote, @Total, @SubTotal, @Codigo, @Neto)", connectionT))
                            {
                                command.Parameters.AddWithValue("@FacturaID", detail.InvoiceId);
                                command.Parameters.AddWithValue("@ProductoID", detail.ProductId);
                                command.Parameters.AddWithValue("@Lote", detail.Quantity);
                                command.Parameters.AddWithValue("@Cantidad", detail.Price);
                                command.Parameters.AddWithValue("@Precio", detail.Lote);
                                command.Parameters.AddWithValue("@Neto", detail.Total);
                                command.Parameters.AddWithValue("@SubTotal", detail.SubTotal);
                                command.Parameters.AddWithValue("@Codigo", detail.ProductCode);
                                command.Parameters.AddWithValue("@Neto", detail.Neto);

                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
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
                // Transacion para si ocurre algun error darle rollback 
                var connectionT = new SQLiteConnection("Data Source= ./bd_sqlite.db");
                connectionT.Open();
                string query = "UPDATE Facturas SET fecha = @Fecha, terminos = @Terminos,cliente_id = @ClienteId" +
                                "num_pedido = @NumPedido, vendedor = @Vendedor, NCF = @ncf" +
                                "WHERE factura_id = @FacturaID";
                using (var transaction = connectionT.BeginTransaction())
                {
                    try
                    {

                        using (var command = new SQLiteCommand(query, connectionT, transaction))
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
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
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

        public List<Invoice> GetAllInvoices()
        {
            var invoices = new List<Invoice>();
            try
            {
                using (connection.GetConnection())
                {
                    connection.OpenConnection();

                    string query = @"SELECT f.factura_id as InvoiceId, f.fecha as Fecha, f.terminos as Terminos, f.cliente_id,
                                    f.num_pedido as NumPedido, f.vendedor as Vendedor, f.NCF as ncf, d.detalle_id as DetalleId, d.factura_id as FacturaId,
                                    d.producto_id as ProductoId, d.cantidad as Cantiadad, d.precio_unitario as Precio, d.lote as Lote,
                                    d.total as Total, d.sub_total as SubTotal, d.codigo as Codigo, d.neto as Neto
                                    FROM Facturas AS f
                                    INNER JOIN Detalle_Factura AS d ON f.factura_id = d.factura_id
                                    ORDER BY f.factura_id;";

                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            Invoice currentInvoice = null; // Track the current invoice being processed

                            while (reader.Read())
                            {
                                int invoiceId = reader.GetInt32(reader.GetOrdinal("InvoiceId"));

                                // Check if it's a new invoice or the same one as before
                                if (currentInvoice == null || currentInvoice.InvoiceID != invoiceId)
                                {
                                    currentInvoice = new Invoice
                                    {
                                        InvoiceID = invoiceId,
                                        Date = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                        Terms = reader.GetString(reader.GetOrdinal("Terminos")),
                                        ClientID = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                        OrderNumer = reader.GetInt32(reader.GetOrdinal("NumPedido")),
                                        SellerName = reader.GetString(reader.GetOrdinal("Vendedor")),
                                        NCF = reader.GetString(reader.GetOrdinal("NCF")),
                                        Details = new List<InvoiceDetails>() // Initialize a new Details list for the invoice
                                    };
                                    invoices.Add(currentInvoice); // Add the new invoice to the list
                                }

                                // Create a new InvoiceDetails object for each detail record
                                InvoiceDetails detail = new InvoiceDetails
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

                                // Add the detail to the current invoice's Details list
                                currentInvoice.Details.Add(detail);
                            }
                        }
                    }
                }

                return invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Invoice GetInvoiceById(int id)
        {
            try
            {
                using (connection.GetConnection())
                {
                    connection.OpenConnection();
                    string query = @"SELECT f.factura_id as InvoiceId, f.fecha as Fecha, f.terminos as Terminos, f.cliente_id,
                                    f.num_pedido as NumPedido, f.vendedor as Vendedor, f.NCF as ncf, d.detalle_id as DetalleId, d.factura_id as FacturaId,
                                    d.producto_id as ProductoId, d.cantidad as Cantiadad, d.precio_unitario as Precio, d.lote as Lote,
                                    d.total as Total, d.sub_total as SubTotal, d.codigo as Codigo, d.neto as Neto
                                    FROM Facturas AS f
                                    INNER JOIN Detalle_Factura AS d ON f.factura_id = d.factura_id
                                    ORDER BY f.factura_id
                                    WHERE f.facturas_id = @FacturaId";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            Invoice currentInvoice = null; // Track the current invoice being processed

                            while (reader.Read())
                            {
                                int invoiceId = reader.GetInt32(reader.GetOrdinal("InvoiceId"));

                                // Check if it's a new invoice or the same one as before
                                if (currentInvoice == null || currentInvoice.InvoiceID != invoiceId)
                                {
                                    return currentInvoice = new Invoice
                                    {
                                        InvoiceID = invoiceId,
                                        Date = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                        Terms = reader.GetString(reader.GetOrdinal("Terminos")),
                                        ClientID = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                        OrderNumer = reader.GetInt32(reader.GetOrdinal("NumPedido")),
                                        SellerName = reader.GetString(reader.GetOrdinal("Vendedor")),
                                        NCF = reader.GetString(reader.GetOrdinal("NCF")),
                                        Details = new List<InvoiceDetails>() // Initialize a new Details list for the invoice
                                    };
                                }

                                // Create a new InvoiceDetails object for each detail record
                                InvoiceDetails detail = new InvoiceDetails
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

                                // Add the detail to the current invoice's Details list
                                currentInvoice.Details.Add(detail);
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
