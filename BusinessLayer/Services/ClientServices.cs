﻿using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using DataLayer.IRepository;
using DataLayer.Repositories;
using DomainLayer.Entities;

namespace BusinessLayer.Services
{
    public class ClientServices : IClientService
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
                ClientName = clientDTO.ClientName,
                Address = clientDTO.Address,
                City = clientDTO.City,
                PhoneNumber = clientDTO.PhoneNumber,
                Fax = clientDTO.Fax,
                Rnc = clientDTO.Rnc,
                Code = clientDTO.Code,
                Email = clientDTO.Email

            };
            _clientRepository.AddClient(client);
        }

        public void UpdateClient(ClientDTO clientDTO)
        {
            var client = new Client
            {
                ClientId = clientDTO.ClientId,
                ClientName = clientDTO.ClientName,
                Address = clientDTO.Address,
                City = clientDTO.City,
                PhoneNumber = clientDTO.PhoneNumber,
                Fax = clientDTO.Fax,
                Rnc = clientDTO.Rnc,
                Code = clientDTO.Code,
                Email = clientDTO.Email
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
                    ClientId=clients.ClientId,
                    ClientName = clients.ClientName,
                    Address = clients.Address,
                    City = clients.City,
                    PhoneNumber = clients.PhoneNumber,
                    Fax = clients.Fax,
                    Rnc = clients.Rnc,
                    Code = clients.Code,
                    Email = clients.Email

                });
            }
            return clientDTO;
        }
         
        public ClientDTO GetByIdClient(int id)
        {
            var client = _clientRepository.GetByIdClient(id);
            ClientDTO clientDTO = new()
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                Address = client.Address,
                City = client.City,
                PhoneNumber = client.PhoneNumber,
                Fax = client.Fax,
                Rnc = client.Rnc,
                Code = client.Code,
                Email = client.Email
            };

            return clientDTO;
        }

        public IEnumerable<ClientDTO> GetAllCLientName()
        {
            List<ClientDTO> list = new();
            var names = _clientRepository.GetAllNameClient();

            foreach (var name in names)
            {
                ClientDTO clientDTO = new()
                {
                    ClientName = name.ClientName,
                    ClientId = name.ClientId,
                };
                list.Add(clientDTO);
            }

            return list;
        }

        public IEnumerable<ClientDTO> SearchClient(string searchTerms)
        {
            var clientDTO = new List<ClientDTO>();
            var matches = _clientRepository.SearchCLint(searchTerms);

            foreach (var clients in matches)
            {
                clientDTO.Add(new ClientDTO
                {
                    ClientId = clients.ClientId,
                    ClientName = clients.ClientName,
                    Address = clients.Address,
                    City = clients.City,
                    PhoneNumber = clients.PhoneNumber,
                    Fax = clients.Fax,
                    Rnc = clients.Rnc,
                    Code = clients.Code,
                    Email = clients.Email

                });
            }
            return clientDTO;
        }
    }
}
