using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;
using System.Globalization;
using System.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataLayer.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ConnectionManager connectionManager;
        public InvoiceRepository()
        {
            connectionManager = new();
        }


        public void AddInvoice(Invoice invoice)
        {
            try
            {
                // Transacion para si ocurre algun error darle rollback 
                var connectionT = new SQLiteConnection(connectionManager.GetConnection());
                connectionT.Open();
                string query =
                        "INSERT INTO Facturas (fecha, terminos, cliente_id, num_pedido, vendedor, NCF, numero, descripcion,sub_total,total, lote_ncf_id,activo) " +
                        "VALUES (@Fecha, @Terminos, @ClienteId, @NumPedido, @Vendedor, @NCF,@NumeroFactura,@Descripcion,@SubTotal,@Total, @LoteNcfId,@Activo); " +
                        "SELECT last_insert_rowid();";
                using (var transaction = connectionT.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SQLiteCommand(query, connectionT, transaction))
                        {
                            command.Parameters.AddWithValue("@Fecha", invoice.Date.ToString("dd-MM-yyyy"));
                            command.Parameters.AddWithValue("@Terminos", invoice.Terms);
                            command.Parameters.AddWithValue("@ClienteId", invoice.ClientID);
                            command.Parameters.AddWithValue("@NumPedido", invoice.OrderNumber);
                            command.Parameters.AddWithValue("@Vendedor", invoice.SellerName);
                            command.Parameters.AddWithValue("@NCF", invoice.NCF);
                            command.Parameters.AddWithValue("@NumeroFactura", invoice.Number);
                            command.Parameters.AddWithValue("@Descripcion", invoice.Description);
                            command.Parameters.AddWithValue("@Total", invoice.Total);
                            command.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                            command.Parameters.AddWithValue("@LoteNcfId", invoice.NcfLoteId);
                            command.Parameters.AddWithValue("@Activo", 1);

                            invoice.InvoiceID = Convert.ToInt32(command.ExecuteScalar());
                        }

                        foreach (var detail in invoice.Details)
                        {
                            using (var command = new SQLiteCommand(
                                "INSERT INTO Detalle_Factura (factura_id, producto_id, cantidad, precio_unitario, lote, " +
                                "codigo, neto)" +
                                "VALUES (@FacturaID, @ProductoID, @Cantidad, @PrecioUnitario, @Lote, @Codigo, @Neto)", connectionT))
                            {
                                command.Parameters.AddWithValue("@FacturaID", invoice.InvoiceID);
                                command.Parameters.AddWithValue("@ProductoID", detail.ProductId);
                                command.Parameters.AddWithValue("@Lote", detail.Lote);
                                command.Parameters.AddWithValue("@Cantidad", detail.Quantity);
                                command.Parameters.AddWithValue("@PrecioUnitario", detail.Price);
                                command.Parameters.AddWithValue("@Codigo", detail.ProductCode);
                                command.Parameters.AddWithValue("@Neto", detail.Neto);

                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        connectionManager.CloseConnection(connectionT);
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        throw new SQLiteException(ex.Message);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in AddInvoice: {ex.Message} at {ex.StackTrace}", ex);
            }
        }


        public void UpdateInvoice(Invoice invoice)
        {
            try
            {
                // Transacion para si ocurre algun error darle rollback 
                var connectionT = new SQLiteConnection(connectionManager.GetConnection());
                connectionT.Open();
                string query = "UPDATE Facturas " +
                                "SET fecha = @Fecha, terminos = @Terminos,cliente_id = @ClienteId" +
                                "num_pedido = @NumPedido, vendedor = @Vendedor, NCF = @ncf, numero = @NumFactura" +
                                "WHERE factura_id = @FacturaID";
                using (var transaction = connectionT.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SQLiteCommand(query, connectionT, transaction))
                        {
                            command.Parameters.AddWithValue("@Fecha", invoice.Date);
                            command.Parameters.AddWithValue("@NumFactura", invoice.Number);
                            command.Parameters.AddWithValue("@ncf", invoice.NCF);
                            command.Parameters.AddWithValue("@Terminos", invoice.Terms);
                            command.Parameters.AddWithValue("@Descripcion", invoice.Description);
                            command.Parameters.AddWithValue("@NumPedido", invoice.OrderNumber);
                            command.Parameters.AddWithValue("@Total", invoice.Total);
                            command.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                            command.Parameters.AddWithValue("@Vendedor", invoice.SellerName);
                            command.Parameters.AddWithValue("@ClienteID", invoice.ClientID);

                            command.ExecuteNonQuery();


                            using (var command2 = new SQLiteCommand("DELETE FROM Detalle_Factura WHERE factura_id = @FacturaID", connectionManager.GetConnection()))
                            {
                                command2.Parameters.AddWithValue("@FacturaID", invoice.InvoiceID);
                                command2.ExecuteNonQuery();
                            }

                            foreach (var details in invoice.Details)
                            {
                                using (var command3 = new SQLiteCommand(
                                    "INSERT INTO Detalles_Factura (factura_id, producto_id, cantidad, precio_unitario, lote, total, sub_total,neto) " +
                                    "VALUES (@FacturaID, @ProductoID, @Cantidad, @PrecioUnitario, @Lote, @Total, @SubTotal, @Codigo, @Neto)", connectionManager.GetConnection()))
                                {
                                    command3.Parameters.AddWithValue("@FacturaID", details.InvoiceId);
                                    command3.Parameters.AddWithValue("@ProductoID", details.ProductId);
                                    command3.Parameters.AddWithValue("@Cantidad", details.Quantity);
                                    command3.Parameters.AddWithValue("@PrecioUnitario", details.Price);
                                    command3.Parameters.AddWithValue("@Lote", details.Lote);
                                    command3.Parameters.AddWithValue("@Codigo", details.ProductCode);
                                    command3.Parameters.AddWithValue("@Neto", details.Neto);

                                    command.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            connectionT.Close();
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        transaction.Rollback();
                        throw new SQLiteException(ex.Message);
                    }
                    finally
                    {
                        connectionManager.CloseConnection(connectionT);

                    }
                }

            }
            catch (SQLiteException e)
            {
                throw new SQLiteException(e.Message);
            }
        }

        public void DeleteInvoice(int id)
        {
            try
            {

                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);

                    using (var transaction = connection.BeginTransaction())
                    {
                        string deleteDetailsQuery = "DELETE FROM Detalle_Factura WHERE factura_id = @FacturaId";
                        using (var command = new SQLiteCommand(deleteDetailsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@FacturaId", id);
                            command.ExecuteNonQuery();
                        }


                        string query = "DELETE FROM Facturas WHERE factura_id = @Id";
                        using (var command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        connection.Close();
                    }

                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException(ex.Message);
            }
        }

        public List<Invoice> GetAllInvoices()
        {
            var invoices = new List<Invoice>();

            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);

                    string query = @"SELECT f.factura_id as InvoiceId, f.fecha as Fecha, f.terminos as Terminos, f.cliente_id as ClienteId, f.numero as Number,
                            f.num_pedido as NumPedido, f.vendedor as Vendedor, f.NCF as ncf, f.descripcion as Descripcion, f.lote_ncf_Id as Ncf_id,d.detalle_id as DetalleId, d.factura_id as FacturaId,
                            d.producto_id as ProductoId, d.cantidad as Cantidad, d.precio_unitario as Precio, d.lote as Lote,
                            f.total as Total, f.sub_total as SubTotal, d.neto as Neto, d.codigo as Codigo
                            FROM Facturas AS f
                            INNER JOIN Detalle_Factura AS d ON f.factura_id = d.factura_id
                            ORDER BY f.factura_id;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            Invoice currentInvoice = null; // Track the current invoice being processed

                            while (reader.Read())
                            {
                                int invoiceId = reader.GetInt32(reader.GetOrdinal("InvoiceId"));
                                // DateTime date = DateTime.ParseExact(reader.GetString(reader.GetOrdinal("Fecha")), "dd-MM-yyyy", CultureInfo.InvariantCulture);


                                // Check if it's a new invoice or the same one as before
                                if (currentInvoice == null || currentInvoice.InvoiceID != invoiceId)
                                {
                                    currentInvoice = new Invoice
                                    {
                                        InvoiceID = invoiceId,
                                        Date = DateTime.ParseExact(reader.GetString(reader.GetOrdinal("Fecha")), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                                        Terms = reader.GetString(reader.GetOrdinal("Terminos")),
                                        ClientID = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                        OrderNumber = reader.GetInt32(reader.GetOrdinal("NumPedido")),
                                        SellerName = reader.GetString(reader.GetOrdinal("Vendedor")),
                                        Number = reader.GetInt32(reader.GetOrdinal("Number")),
                                        NCF = reader.GetString(reader.GetOrdinal("ncf")),
                                        NcfLoteId = reader.GetInt32(reader.GetOrdinal("Ncf_id")),
                                        Description = reader.IsDBNull(reader.GetOrdinal("Descripcion"))
                                                    ? string.Empty
                                                    : reader.GetString(reader.GetOrdinal("Descripcion")),
                                        Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                        SubTotal = reader.GetDouble(reader.GetOrdinal("SubTotal")),
                                        Details = new List<InvoiceDetails>() // Initialize a new Details list for the invoice
                                    };
                                    invoices.Add(currentInvoice); // Add the new invoice to the list
                                }

                                int Quantity = reader.GetInt32(reader.GetOrdinal("Cantidad"));

                                // Create a new InvoiceDetails object for each detail record
                                InvoiceDetails detail = new InvoiceDetails
                                {
                                    InvoiceDetailsId = reader.GetInt32(reader.GetOrdinal("DetalleId")),
                                    InvoiceId = reader.GetInt32(reader.GetOrdinal("FacturaId")),
                                    ProductId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantidad")),
                                    Price = reader.GetDouble(reader.GetOrdinal("Precio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")), // Corrected type
                                    ProductCode = reader.GetString(reader.GetOrdinal("Codigo")), // Added for Codigo
                                    Neto = reader.GetDouble(reader.GetOrdinal("Neto"))
                                };

                                // Add the detail to the current invoice's Details list
                                currentInvoice.Details.Add(detail);
                            }
                        }
                    }
                }

                return invoices;
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetAllInvoices: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public IEnumerable<InvoiceGridView> GetInvoicesGrid()
        {
            List<InvoiceGridView> invoices = new();
            try
            {
                connectionManager.GetConnection();
                using (var connection = connectionManager.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM VerFacturas";
                    using(var command = new SQLiteCommand(query,connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {

                            while(reader.Read())
                            {
                                InvoiceGridView invoice = new()
                                {
                                    InvoiceId = reader.GetInt32(0),
                                    ClientId = reader.GetInt32(2),
                                    DetailId = reader.GetInt32(3),
                                    InvoiceNumber = reader.GetInt32(4),
                                    ClientName = reader.GetString(5),
                                    Date = DateTime.ParseExact(reader.GetString(reader.GetOrdinal("Fecha")), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                                    SellerName = reader.GetString(7),
                                    Terms = reader.GetString(8),
                                    Description = reader.GetString(9),
                                    OrderNumber = reader.GetInt32(10),
                                    Total = reader.GetDouble(11),
                                };
                                invoices.Add(invoice);
                            }
                        }
                        return invoices;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Exception in GeInvoicesGrid {ex.Message} {ex.StackTrace}");
            }
        }

        public Invoice GetInvoiceById(int id)
        {
            var invoice = new Invoice();
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = @"
                        SELECT f.factura_id as InvoiceId, f.fecha as Fecha, f.terminos as Terminos, f.cliente_id as ClienteId, f.numero as Number,
                        f.num_pedido as NumPedido, f.vendedor as Vendedor, f.NCF as ncf, f.descripcion as Descripcion ,d.detalle_id as DetalleId, f.lote_ncf_Id as Ncf_id,d.factura_id as FacturaId,
                        d.producto_id as ProductoId, d.cantidad as Cantidad, d.precio_unitario as Precio, d.lote as Lote,
                        f.total as Total, f.sub_total as SubTotal, d.neto as Neto, d.codigo as Codigo
                        FROM Facturas AS f
                        INNER JOIN Detalle_Factura AS d ON f.factura_id = d.factura_id
                        WHERE f.factura_id = @Id
                        ORDER BY f.factura_id;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (invoice.InvoiceID == 0)
                                {
                                    invoice = new Invoice
                                    {
                                        InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceId")),
                                        Date = DateTime.ParseExact(reader.GetString(reader.GetOrdinal("Fecha")), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                                        Terms = reader.GetString(reader.GetOrdinal("Terminos")),
                                        ClientID = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                        OrderNumber = reader.GetInt32(reader.GetOrdinal("NumPedido")),
                                        SellerName = reader.GetString(reader.GetOrdinal("Vendedor")),
                                        Number = reader.GetInt32(reader.GetOrdinal("Number")),
                                        NCF = reader.GetString(reader.GetOrdinal("NCF")),
                                        NcfLoteId = reader.GetInt32(reader.GetOrdinal("Ncf_id")),
                                        Description = reader.GetString(reader.GetOrdinal("Descripcion")),
                                        Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                        SubTotal = reader.GetDouble(reader.GetOrdinal("SubTotal")),
                                        Details = new List<InvoiceDetails>()
                                    };
                                }

                                InvoiceDetails detail = new InvoiceDetails
                                {
                                    InvoiceDetailsId = reader.GetInt32(reader.GetOrdinal("DetalleId")),
                                    InvoiceId = reader.GetInt32(reader.GetOrdinal("FacturaId")),
                                    ProductId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantidad")),
                                    Price = reader.GetDouble(reader.GetOrdinal("Precio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
                                    Neto = reader.GetDouble(reader.GetOrdinal("Neto")),
                                    ProductCode = reader.GetString(reader.GetOrdinal("Codigo"))
                                };

                                invoice.Details.Add(detail);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetInvoiceById: {ex.Message} at {ex.StackTrace}", ex);
            }

            return invoice;
        }

        public int GetMaxCode(string column)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = $"SELECT MAX({column}) FROM Facturas";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetMaxCode: {ex.Message} at {ex.StackTrace}", ex);
            }
        }
    }
}
