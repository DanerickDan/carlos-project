﻿using DataLayer.Connection;
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



        public List<InvoiceDetails> GetAllInvoiceDetail()
        {
            var details = new List<InvoiceDetails>();
            try
            {
                using(var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM Detalle_Factura;";
                    using(var command = new SQLiteCommand(query, connection))
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
                                    Price = reader.GetDouble(reader.GetOrdinal("Precio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
                                    Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                    SubTotal = reader.GetDouble(reader.GetOrdinal("SubTotal")),
                                    ProductCode = reader.GetInt32(reader.GetOrdinal("Codigo")),
                                    Neto = reader.GetDouble(reader.GetOrdinal("Neto"))
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
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM Detalle_Factura WHEREN detalle_id = @Id;";
                    using (var command = new SQLiteCommand(query, connection))
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
                                    Price = reader.GetDouble(reader.GetOrdinal("Precio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
                                    Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                    SubTotal = reader.GetDouble(reader.GetOrdinal("SubTotal")),
                                    ProductCode = reader.GetInt32(reader.GetOrdinal("Codigo")),
                                    Neto = reader.GetDouble(reader.GetOrdinal("Neto"))
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
