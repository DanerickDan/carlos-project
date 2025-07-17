using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.Common;
using System.Data.SQLite;
using System.Transactions;

namespace DataLayer.Repositories
{
    public class NcfRepository : INcfRepository
    {
        private readonly ConnectionManager connectionManager;

        public NcfRepository()
        {
            connectionManager = new();
        }
        public void AddLot(NcfLot lote)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    using (var transaction = connection.BeginTransaction())
                    {
                        string query = @"INSERT INTO NCF_Lotes (TipoNCF, PrefijoNCF, SecuenciaInicio, SecuenciaFin, SecuenciaActual, FechaExpiracion, Disponible) 
                            VALUES (@tipo, @prefijo, @inicio, @fin, @actual, @fecha, @disponible)";
                        using (var command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@tipo", lote.TipoNCF);
                            command.Parameters.AddWithValue("@prefijo", lote.PrefijoNCF);
                            command.Parameters.AddWithValue("@inicio", lote.SecuenciaInicio);
                            command.Parameters.AddWithValue("@fin", lote.SecuenciaFin);
                            command.Parameters.AddWithValue("@actual", lote.SecuenciaActual);
                            command.Parameters.AddWithValue("@fecha", lote.FechaExpiracion);
                            command.Parameters.AddWithValue("@disponible", lote.Disponible ? 1 : 0);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        // Asegúrate de confirmar la transacción
                        connectionManager.CloseConnection(connection);
                    }
                }
            }
            catch(SQLiteException ex) 
            {
                throw new SQLiteException($"Error in AddLot: {ex.Message}", ex);
            }
        }

        public NcfLot GetFirstAvailableLot(string tipoNCF)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = @"SELECT * FROM NCF_Lotes WHERE TipoNCF = @tipoNCF AND Disponible = 1 AND FechaExpiracion >= DATE('now') ORDER BY Id LIMIT 1";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tipoNCF", tipoNCF);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new NcfLot
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    TipoNCF = reader["TipoNCF"].ToString(),
                                    PrefijoNCF = reader["PrefijoNCF"].ToString(),
                                    SecuenciaInicio = Convert.ToInt32(reader["SecuenciaInicio"]),
                                    SecuenciaFin = Convert.ToInt32(reader["SecuenciaFin"]),
                                    SecuenciaActual = Convert.ToInt32(reader["SecuenciaActual"]),
                                    FechaExpiracion = Convert.ToDateTime(reader["FechaExpiracion"]),
                                    Disponible = Convert.ToBoolean(reader["Disponible"])
                                };
                            }
                        }
                        return null;
                    }
                }

            }
            catch(SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetFirstAvailableLot: {ex.Message}", ex);
            }
        }

        public NcfLot GetNcfLotDTOById(int id)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = @"SELECT * FROM NCF_Lotes WHERE Id = @id LIMIT 1";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new NcfLot
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    TipoNCF = reader["TipoNCF"].ToString(),
                                    PrefijoNCF = reader["PrefijoNCF"].ToString(),
                                    SecuenciaInicio = Convert.ToInt32(reader["SecuenciaInicio"]),
                                    SecuenciaFin = Convert.ToInt32(reader["SecuenciaFin"]),
                                    SecuenciaActual = Convert.ToInt32(reader["SecuenciaActual"]),
                                    FechaExpiracion = Convert.ToDateTime(reader["FechaExpiracion"]),
                                    Disponible = Convert.ToBoolean(reader["Disponible"])
                                };
                            }
                        }

                        return null; // No se encontró un lote con ese ID
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetNcfLotDTOById: {ex.Message}", ex);
            }
        }


        public void UpdateLot(NcfLot lote)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = @"UPDATE NCF_Lotes SET SecuenciaActual = @actual, Disponible = @disponible WHERE Id = @id";
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (var command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@actual", lote.SecuenciaActual);
                            command.Parameters.AddWithValue("@disponible", lote.Disponible ? 1 : 0);
                            command.Parameters.AddWithValue("@id", lote.Id);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        connection.Close();
                    }
                }
            }
            catch(SQLiteException ex)
            {
                throw new SQLiteException($"Error in UpdateLot: {ex.Message}", ex);
            }
        }
    }
}
