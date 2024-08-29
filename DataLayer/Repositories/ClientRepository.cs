using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ConnectionManager connectionManager;
        public ClientRepository()
        {
            connectionManager = new();
        }

        public void AddClient(Client client)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    using (var transaction = connection.BeginTransaction())
                    {
                        string query = "INSERT INTO Clientes(nombre, direccion, ciudad, telefono, fax, RNC, codigo, email, activo)" +
                            "VALUES(@Nombre, @Direccion, @Ciudad, @Telefono, @Fax, @RNC, @Code, @Email, @Activo)";
                        using (var command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Nombre", client.ClientName);
                            command.Parameters.AddWithValue("@Direccion", client.Address);
                            command.Parameters.AddWithValue("@Ciudad", client.City);
                            command.Parameters.AddWithValue("@Telefono", client.PhoneNumber);
                            command.Parameters.AddWithValue("@Fax", client.Fax);
                            command.Parameters.AddWithValue("@RNC", client.Rnc);
                            command.Parameters.AddWithValue("@Code", client.Code);
                            command.Parameters.AddWithValue("@Email", client.Email);
                            command.Parameters.AddWithValue("@Activo", 1);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Asegúrate de confirmar la transacción
                        connection.Close();
                    }
                }

            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in AddClient: {ex.Message}", ex);
            }
        }

        public void UpdateClient(Client client)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "UPDATE Clientes SET nombre = @Nombre, direccion = @Direccion, ciudad = @Ciudad, telefono = @Telefono" +
                        ", fax = @Fax, RNC = @rnc, codigo = @Code, email = @Email WHERE clientes_id = @ClienteId";
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (var command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Nombre", client.ClientName);
                            command.Parameters.AddWithValue("@Direccion", client.Address);
                            command.Parameters.AddWithValue("@Ciudad", client.City);
                            command.Parameters.AddWithValue("@Telefono", client.PhoneNumber);
                            command.Parameters.AddWithValue("@Fax", client.Fax);
                            command.Parameters.AddWithValue("@rnc", client.Rnc);
                            command.Parameters.AddWithValue("@ClientId", client.ClientId);
                            command.Parameters.AddWithValue("@Email", client.Email);
                            command.Parameters.AddWithValue("@ClienteId", client.ClientId);

                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        connection.Close();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in UpdateClient: {ex.Message}", ex);
            }
        }

        public void DeleteClient(int id)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "UPDATE Clientes SET activo = 0  WHERE clientes_id = @ClientId";
                    using (var transaction = new SQLiteTransaction(connection, true))
                    {
                        using (var command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ClientId", id);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw new SQLiteException($"Error in DeleteClient: {e.Message}", e);
            }
        }

        public List<Client> GetAllCLient()
        {
            var clients = new List<Client>();
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM Clientes WHERE activo = 1";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clients.Add(new Client
                                {
                                    ClientId = reader.GetInt32(0),
                                    ClientName = reader.GetString(1),
                                    Address = reader.GetString(2),
                                    City = reader.GetString(3),
                                    PhoneNumber = reader.GetString(4),
                                    Fax = reader.GetString(5),
                                    Rnc = reader.GetString(6),
                                    Code = reader.GetInt32(7),
                                    Email = reader.GetString(8)
                                });
                            }
                        }

                    }
                }
                return clients;
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetAllCLient: {ex.Message} at {ex.StackTrace}", ex);
            }

        }


        public Client GetByIdClient(int id)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM Clientes WHERE clientes_id = @ClientId and activo = 1";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", id);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new Client
                                {
                                    ClientId = reader.GetInt32(0),
                                    ClientName = reader.GetString(1),
                                    Address = reader.GetString(2),
                                    City = reader.GetString(3),
                                    PhoneNumber = reader.GetString(4),
                                    Fax = reader.GetString(5),
                                    Rnc = reader.GetString(6),
                                    Code = reader.GetInt32(7),
                                    Email = reader.GetString(8)
                                };
                            }
                        }

                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetClientById: {ex.Message}", ex);
            }
            return null;
        }

        public IEnumerable<string> GetAllNameClient()
        {
            List<string> names = new();
            string nombre = "";
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT Nombre FROM VerClientes WHERE activo = 1";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nombre = reader.GetString(0);
                                names.Add(nombre);
                            }
                            return names;
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetAllNameClient: {ex.Message}", ex);
            }
        }

        public bool ExistCode(int code, string type)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT COUNT(1) FROM Clientes Where @Type = @Code";
                    using (var command = new SQLiteCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Type",type);
                        command.Parameters.AddWithValue("@Code",code);
                        var count = command.ExecuteScalar();
                        if(count != null)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in ExistCode: {ex.Message}", ex);
            }
        }
    }
}
