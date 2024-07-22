using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows;


namespace DataLayer.Connection
{
    public class ConnectionManager
    {
        private readonly SQLiteConnection _connection;
        private readonly string ConnectionString = "Data Source=C:\\Users\\pasantetic\\source\\repos\\ProyectoCarlos\\DataLayer\\databasePrueba.db";

        // Class to manage de connection to sqlite

        public ConnectionManager()
        {
            _connection = new("Data Source=C:\\Users\\pasantetic\\source\\repos\\ProyectoCarlos\\DataLayer\\databasePrueba.db");
        }

        public String GetConnectionString()
        {
            return ConnectionString;
        }

        public SQLiteConnection GetConnection()
        {
            try
            {
                return _connection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void OpenConnection()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void CloseConnection()
        {
            try
            {
                _connection?.Close();
            }
            catch (Exception ex)
            {
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
