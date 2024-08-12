using System.Data.SQLite;
using System.Configuration;

namespace DataLayer.Connection
{
    public class ConnectionManager
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;



        public SQLiteConnection GetConnection()
        {
            try
            {
                return new SQLiteConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void OpenConnection(SQLiteConnection connection)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error opening connection: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public void CloseConnection(SQLiteConnection connection)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error closing connection: {ex.Message} at {ex.StackTrace}", ex);
            }
        }
    }
}
