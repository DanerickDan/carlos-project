using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ConnectionManager connection;
        public ClientRepository() 
        {
            connection = new();
        }

        public void AddClient(Client client)
        {
            try
            {
                connection.OpenConnection();
                using (connection.GetConnection())
                {
                    string query = "INSERT INTO Clientes(nombre, direccion, ciudad, telefono, fax, RNC)" +
                        "VALUES(@Nombre, @Direcccion, @Ciudad, @Telefono, @Fax, @RNC)";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Nombre", client.ClientName);
                        command.Parameters.AddWithValue("@Direccion", client.Address);
                        command.Parameters.AddWithValue("@Ciudad", client.City);
                        command.Parameters.AddWithValue("@Telefono", client.PhoneNumber);
                        command.Parameters.AddWithValue("@Fax", client.Fax);
                        command.Parameters.AddWithValue("@RNC", client.Rnc);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateClient(Client client) 
        {
            try
            {
                connection.CloseConnection();
                using (connection.GetConnection())
                {
                    string query = "UPDATE Clientes SET nombre = @Nombre, direccion = @Direccion, ciudad = @Ciudad, telefono = @Telefono" +
                        ", fax = @Fax, RNC = @rnc WHERE clientes_id = @ClienteId";
                    using(var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Nombre", client.ClientName);
                        command.Parameters.AddWithValue("@Direccion", client.Address);
                        command.Parameters.AddWithValue("@Ciudad", client.City);
                        command.Parameters.AddWithValue("@Telefono", client.PhoneNumber);
                        command.Parameters.AddWithValue("@Fax", client.Fax);
                        command.Parameters.AddWithValue("@rnc", client.Rnc);
                        command.Parameters.AddWithValue("@ClientId", client.ClienstId);

                        command.ExecuteNonQuery();
                    }
                    connection.CloseConnection();
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
                connection.OpenConnection();
                using(connection.GetConnection())
                {
                    string query = "DELETE FROM Clientes WHERE clientes_id = @ClientId";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@ClientId", id);
                        command.ExecuteNonQuery();
                    }
                }
                connection.CloseConnection();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Client> GetAllCLient()
        {
            var clients = new List<Client>();
            connection.OpenConnection();
            using (connection.GetConnection())
            {
                string query = "SELECT * FROM Clientes";
                using(var command = new SQLiteCommand(query, connection.GetConnection()))
                {
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                ClienstId = reader.GetInt32(0),
                                ClientName = reader.GetString(1),
                                Address = reader.GetString(2),
                                City = reader.GetString(3),
                                PhoneNumber = reader.GetString(4),
                                Fax = reader.GetString(5),
                                Rnc = reader.GetString(6)
                            });
                        }
                    }
                    connection.CloseConnection();
                }
                return clients;
            }
        }

        public Client GetByIdClient()
        {
            try
            {
                connection.OpenConnection();
                using (connection.GetConnection())
                {
                    string query = "SELECT * FROM Clientes WHERE clientes_id = @ClientId";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new Client
                                {
                                    ClienstId = reader.GetInt32(0),
                                    ClientName = reader.GetString(1),
                                    Address = reader.GetString(2),
                                    City = reader.GetString(3),
                                    PhoneNumber = reader.GetString(4),
                                    Fax = reader.GetString(5),
                                    Rnc = reader.GetString(6)
                                };
                            }
                        }
                        connection.CloseConnection();
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
