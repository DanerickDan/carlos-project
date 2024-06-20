using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IRepository
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        List<Client> GetAllCLient();
        Client GetByIdClient();
    }
}
