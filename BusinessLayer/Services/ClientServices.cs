using BusinessLayer.Model;
using DataLayer.IRepository;
using DataLayer.Repositories;
using DomainLayer.Entities;

namespace BusinessLayer.Services
{
    public class ClientServices
    {
        private readonly IClientRepository _clientRepository;
        public ClientServices() 
        {
            _clientRepository = new ClientRepository();
        }

        public void AddClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                ClienstId = clientDTO.ClienstId,
                ClientName = clientDTO.ClientName,
                Address = clientDTO.Address,
                City = clientDTO.City,
                PhoneNumber = clientDTO.PhoneNumber,
                Fax = clientDTO.Fax,
                Rnc = clientDTO.Rnc
            };
            _clientRepository.AddClient(client);
        }

        public void UpdateClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                ClienstId = clientDTO.ClienstId,
                ClientName = clientDTO.ClientName,
                Address = clientDTO.Address,
                City = clientDTO.City,
                PhoneNumber = clientDTO.PhoneNumber,
                Fax = clientDTO.Fax,
                Rnc = clientDTO.Rnc
            };
            _clientRepository.UpdateClient(client);
        }

        public void DeleteClient(int id)
        {
            _clientRepository.DeleteClient(id);
        }

        public List<ClientDTO> GetAllCLient()
        {
            var clientDTO = new List<ClientDTO>();
            var client = _clientRepository.GetAllCLient();
            foreach (var clients in client)
            {
                clientDTO.Add(new ClientDTO
                {
                    ClienstId=clients.ClienstId,
                    ClientName = clients.ClientName,
                    Address = clients.Address,
                    City = clients.City,
                    PhoneNumber = clients.PhoneNumber,
                    Fax = clients.Fax,
                    Rnc = clients.Rnc

                });
            }
            return clientDTO;
        }

        public ClientDTO GetByIdClient()
        {
            var client = _clientRepository.GetByIdClient();
            var clientDTO = new ClientDTO
            {
                ClienstId = client.ClienstId,
                ClientName = client.ClientName,
                Address = client.Address,
                City = client.City,
                PhoneNumber = client.PhoneNumber,
                Fax = client.Fax,
                Rnc = client.Rnc
            };

            return clientDTO;
        }
    }
}
