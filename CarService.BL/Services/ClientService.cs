using CarService.BL.Interfaces;
using CarService.DL.InMemoryRepos;
using CarService.Models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarService.BL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger _logger;

        public ClientService(IClientRepository clientRepository, ILogger logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }
        public Clients Create(Clients client)
        {
            var index = _clientRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            client.Id = (int)(index != null ? index + 1 : 1);

            return _clientRepository.Create(client);
        }

        public Clients Delete(int id)
        {
            return _clientRepository.Delete(id);
        }

        public IEnumerable<Clients> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public Clients GetById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public Clients Update(Clients client)
        {
            

            return _clientRepository.Update(client);
        }
    }
}
