using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        List<Client> GetAllCLient();
        Client GetByIdClient(int id);
        IEnumerable<Client> GetAllNameClient();
        bool ExistCode(int code, string type);
        IEnumerable<Client> SearchCLint(string searchTerm);
    }
}
