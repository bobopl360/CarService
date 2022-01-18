using CarService.BL.Interfaces;
using CarService.DL.InMemoryRepos;
using CarService.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CarService.BL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public Service Create(Service service)
        {
            return _serviceRepository.Create(service);
        }

        public Service Delete(int id)
        {
            return _serviceRepository.Delete(id);
        }

        public IEnumerable<Service> GetAll()
        {
            return _serviceRepository.GetAll();
        }

        public Service GetById(int id)
        {
            return _serviceRepository.GetById(id);
        }

        public Service Update(Service service)
        {
            var index = _serviceRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            service.Id = (int)(index != null ? index + 1 : 1);

            return _serviceRepository.Create(service);
        }
    }
}
