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
                    string query = "INSERT INTO Clientes(nombre, direccion, ciudad, telefono, fax, RNC, codigo)" +
                        "VALUES(@Nombre, @Direcccion, @Ciudad, @Telefono, @Fax, @RNC, @Code)";
                    using (var command = new SQLiteCommand(query, connectionManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Nombre", client.ClientName);
                        command.Parameters.AddWithValue("@Direccion", client.Address);
                        command.Parameters.AddWithValue("@Ciudad", client.City);
                        command.Parameters.AddWithValue("@Telefono", client.PhoneNumber);
                        command.Parameters.AddWithValue("@Fax", client.Fax);
                        command.Parameters.AddWithValue("@RNC", client.Rnc);
                        command.Parameters.AddWithValue("@Code", client.Code);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                        ", fax = @Fax, RNC = @rnc WHERE clientes_id = @ClienteId";
                    using (var command = new SQLiteCommand(query, connectionManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Nombre", client.ClientName);
                        command.Parameters.AddWithValue("@Direccion", client.Address);
                        command.Parameters.AddWithValue("@Ciudad", client.City);
                        command.Parameters.AddWithValue("@Telefono", client.PhoneNumber);
                        command.Parameters.AddWithValue("@Fax", client.Fax);
                        command.Parameters.AddWithValue("@rnc", client.Rnc);
                        command.Parameters.AddWithValue("@ClientId", client.ClientId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    using (var command = new SQLiteCommand(query, connectionManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@ClientId", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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

    public Client GetByIdClient()
    {
        try
        {
            using (var connection = connectionManager.GetConnection())
            {
                connectionManager.OpenConnection(connection);
                string query = "SELECT * FROM Clientes WHERE clientes_id = @ClientId";
                using (var command = new SQLiteCommand(query, connectionManager.GetConnection()))
                {
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
            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
}
