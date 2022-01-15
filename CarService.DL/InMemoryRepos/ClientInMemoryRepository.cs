using CarService.DL.InMemoryDb;
using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarService.DL.InMemoryRepos
{
    public class ClientInMemoryRepository : IClientRepository
    {
        public ClientInMemoryRepository()
        {

        }

        public Clients Create(Clients client)
        {
            ClientInMemoryCollection.ClientsDb.Add(client);

            return client;

        }

        public Clients Delete(int id)
        {
            var client = ClientInMemoryCollection.ClientsDb.FirstOrDefault(client => client.Id == id);

            ClientInMemoryCollection.ClientsDb.Remove(client);

            return client;
        }

        public IEnumerable<Clients> GetAll()
        {
            return ClientInMemoryCollection.ClientsDb;

        }

        public Clients GetById(int id)
        {
           return ClientInMemoryCollection.ClientsDb.FirstOrDefault(x => x.Id == id);
        }

        public Clients Update(Clients client)
        {
            var result = ClientInMemoryCollection.ClientsDb.FirstOrDefault(x => x.Id == client.Id);

            result.Name = client.Name;
            result.PaymentType = client.PaymentType;
            result.Car = client.Car;

            return result;
        }
    }
}
