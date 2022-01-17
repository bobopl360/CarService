using CarService.DL.InMemoryDb;
using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarService.DL.InMemoryRepos
{
    public class ServiceInMemoryRepository : IServiceRepository
    {
        public ServiceInMemoryRepository()
        {

        }

        public Service Create(Service service)
        {
           ServiceInMemoryCollection.ServiceItemsDb.Add(service);

            return service;
        }

        public Service Delete(int id)
        {
            var service = ServiceInMemoryCollection.ServiceItemsDb.FirstOrDefault(service => service.Id == id);

            ServiceInMemoryCollection.ServiceItemsDb.Remove(service);

            return service;
        }

        public IEnumerable<Service> GetAll()
        {
            return ServiceInMemoryCollection.ServiceItemsDb;
        }

        public Service GetById(int id)
        {
            return ServiceInMemoryCollection.ServiceItemsDb.FirstOrDefault(x => x.Id == id);
        }

        public Service Update(Service service)
        {
            var result = ServiceInMemoryCollection.ServiceItemsDb.FirstOrDefault(x => x.Id == service.Id);

            result.Id = service.Id;
            result.Name = service.Name;
            result.Price = service.Price;
            result.Products = service.Products;
            result.Type = service.Type;

            return result;
        }
    }
}
