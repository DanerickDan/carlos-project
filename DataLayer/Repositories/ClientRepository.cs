using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
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
                    string query = "INSERT INTO Clientes(nombre, direccion, ciudad, telefono, fax, RNC, codigo, email)" +
                        "VALUES(@Nombre, @Direcccion, @Ciudad, @Telefono, @Fax, @RNC, @Code, @Email)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", client.ClientName);
                        command.Parameters.AddWithValue("@Direccion", client.Address);
                        command.Parameters.AddWithValue("@Ciudad", client.City);
                        command.Parameters.AddWithValue("@Telefono", client.PhoneNumber);
                        command.Parameters.AddWithValue("@Fax", client.Fax);
                        command.Parameters.AddWithValue("@RNC", client.Rnc);
                        command.Parameters.AddWithValue("@Code", client.Code);
                        command.Parameters.AddWithValue("@Email", client.Email);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in AddClient: {ex.Message}", ex);
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
                    using (var command = new SQLiteCommand(query, connection))
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateClient: {ex.Message}", ex);
            }
        }

        public void DeleteClient(int id)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "DELETE FROM Clientes WHERE clientes_id = @ClientId";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error in DeleteClient: {e.Message}", e);
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
                    string query = "SELECT * FROM Clientes";
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
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllInvoices: {ex.Message} at {ex.StackTrace}", ex);
            }

        }


        public Client GetByIdClient(int id)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM Clientes WHERE clientes_id = @ClientId";
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
            catch (Exception ex)
            {
                throw new Exception($"Error in GetClientById: {ex.Message}", ex);
            }
            return null;
        }
    }
}
