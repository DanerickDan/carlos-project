using BusinessLayer.Model;

namespace BusinessLayer.Interfaces.IServices
{
    public interface IClientService
    {
        public void AddClient(ClientDTO clientDTO);
        public void UpdateClient(ClientDTO clientDTO);
        public void DeleteClient(int id);
        public List<ClientDTO> GetAllCLient();
        public ClientDTO GetByIdClient(int id);
    }
}
