﻿using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;

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
                            command.Parameters.AddWithValue("@NumPedido", invoice.OrderNumber);
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
                                command.Parameters.AddWithValue("@FacturaID", invoice.InvoiceID);
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
                        connectionManager.CloseConnection(connectionT);
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
                            command.Parameters.AddWithValue("@NumPedido", invoice.OrderNumber);
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
                                    command3.Parameters.AddWithValue("@Total", details.Total);
                                    command3.Parameters.AddWithValue("@SubTotal", details.SubTotal);
                                    command3.Parameters.AddWithValue("@Codigo", details.ProductCode);
                                    command3.Parameters.AddWithValue("@Neto", details.Neto);

                                    command.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connectionManager.CloseConnection(connectionT);

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

                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);

                    string deleteDetailsQuery = "DELETE FROM Detalle_Factura WHERE factura_id = @FacturaId";
                    using (var command = new SQLiteCommand(deleteDetailsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FacturaId", id);
                        command.ExecuteNonQuery();
                    }


                    string query = "DELETE FROM Facturas WHERE factura_id = @Id";
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

        public List<Invoice> GetAllInvoices()
        {
            var invoices = new List<Invoice>();

            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);

                    string query = @"SELECT f.factura_id as InvoiceId, f.fecha as Fecha, f.terminos as Terminos, f.cliente_id as ClienteId, f.numero as Number,
                            f.num_pedido as NumPedido, f.vendedor as Vendedor, f.NCF as ncf, d.detalle_id as DetalleId, d.factura_id as FacturaId,
                            d.producto_id as ProductoId, d.cantidad as Cantidad, d.precio_unitario as Precio, d.lote as Lote,
                            d.total as Total, d.sub_total as SubTotal, d.neto as Neto, d.codigo as Codigo
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

                                // Check if it's a new invoice or the same one as before
                                if (currentInvoice == null || currentInvoice.InvoiceID != invoiceId)
                                {
                                    currentInvoice = new Invoice
                                    {
                                        InvoiceID = invoiceId,
                                        Date = DateTime.Parse(reader.GetString(reader.GetOrdinal("Fecha"))), // Corrected
                                        Terms = reader.GetString(reader.GetOrdinal("Terminos")),
                                        ClientID = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                        OrderNumber = reader.GetInt32(reader.GetOrdinal("NumPedido")),
                                        SellerName = reader.GetString(reader.GetOrdinal("Vendedor")),
                                        Number = reader.GetInt32(reader.GetOrdinal("Number")),
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
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantidad")),
                                    Price = reader.GetDouble(reader.GetOrdinal("Precio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")), // Corrected type
                                    Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                    SubTotal = reader.GetDouble(reader.GetOrdinal("SubTotal")),
                                    ProductCode = reader.GetInt32(reader.GetOrdinal("Codigo")), // Added for Codigo
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
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllInvoices: {ex.Message} at {ex.StackTrace}", ex);
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
                        f.num_pedido as NumPedido, f.vendedor as Vendedor, f.NCF as ncf, d.detalle_id as DetalleId, d.factura_id as FacturaId,
                        d.producto_id as ProductoId, d.cantidad as Cantidad, d.precio_unitario as Precio, d.lote as Lote,
                        d.total as Total, d.sub_total as SubTotal, d.neto as Neto, d.codigo as Codigo
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
                                        Date = DateTime.Parse(reader.GetString(reader.GetOrdinal("Fecha"))),
                                        Terms = reader.GetString(reader.GetOrdinal("Terminos")),
                                        ClientID = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                        OrderNumber = reader.GetInt32(reader.GetOrdinal("NumPedido")),
                                        SellerName = reader.GetString(reader.GetOrdinal("Vendedor")),
                                        Number = reader.GetInt32(reader.GetOrdinal("Number")),
                                        NCF = reader.GetString(reader.GetOrdinal("NCF")),
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
                                    Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                    SubTotal = reader.GetDouble(reader.GetOrdinal("SubTotal")),
                                    Neto = reader.GetDouble(reader.GetOrdinal("Neto")),
                                    ProductCode = reader.GetInt32(reader.GetOrdinal("Codigo"))
                                };

                                invoice.Details.Add(detail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoice;
        }
    }
}
