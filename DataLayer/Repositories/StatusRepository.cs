using DataLayer.Connection;

namespace DataLayer.Repositories
{
    public class StatusRepository
    {
        private ConnectionManager connection;
        public StatusRepository()
        {
            connection = new();
        }

        public void GetStatus(int id)
        {
            try
            {
                connection.OpenConnection();
                string query = "SELECT descripcion FROM EstadoPedido WHERE estado_id = @Id";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateStatus()
        {

        }

    }
}
