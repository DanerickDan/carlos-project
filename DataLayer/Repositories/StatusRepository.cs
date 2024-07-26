using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private ConnectionManager connectionManager;
        public StatusRepository()
        {
            connectionManager = new();
        }

        public List<Status> GetAllStatus()
        {
            var statusList = new List<Status>();
            try
            {
                using(var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT * FROM EstadoPedido";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                statusList.Add(new Status
                                {
                                    StatusId = reader.GetInt32(0),
                                    Descripcion = reader.GetString(1)
                                });
                            }
                        }

                    }
                    return statusList;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Status GetStatusById(int id)
        {
            try
            {
                using( var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);

                    string query = "SELECT * FROM EstadoPedido WHERE estado_id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            command.Parameters.AddWithValue("@Id", id);

                            return new Status
                            {
                                StatusId = reader.GetInt32(0),
                                Descripcion = reader.GetString(1)
                            };

                        }

                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
