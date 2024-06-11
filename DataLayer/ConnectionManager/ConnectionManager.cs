using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows;


namespace DataLayer.ConnectionManager
{
    public class ConnectionManager
    {
        private readonly SQLiteConnection _connection;

        public ConnectionManager()
        {
            _connection = new("Data Source= ./bd_sqlite.db");
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
                _connection.Close();
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
