using BusinessLayer.Model;

namespace BusinessLayer.Interfaces.IServices
{
    public interface IClientService
    {
        void AddClient(ClientDTO clientDTO);
        void UpdateClient(ClientDTO clientDTO);
        void DeleteClient(int id);
        List<ClientDTO> GetAllCLient();
        ClientDTO GetByIdClient(int id);
        IEnumerable<ClientDTO> GetAllCLientName();

        IEnumerable<ClientDTO> SearchClient(string searchTerms);

    }
}
