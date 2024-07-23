using System.Data.SQLite;


namespace DataLayer.Connection
{
    public class ConnectionManager
    {
        private readonly string ConnectionString = "Data Source=C:\\Users\\pasantetic\\source\\repos\\ProyectoCarlos\\DataLayer\\databasePrueba2.db";
        private readonly SQLiteConnection _connection;
        // Class to manage the connection to SQLite

        public ConnectionManager()
        {
            _connection = new SQLiteConnection(ConnectionString);
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
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
