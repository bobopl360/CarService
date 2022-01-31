using CarService.BL.Interfaces;
using CarService.DL.InMemoryRepos;
using CarService.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace CarService.BL.Services
{
    public class CarsService : ICarsService
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger _logger;

        public CarsService(ICarRepository carRepository, ILogger logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public Cars Create(Cars cars)
        {
            var index = _carRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            cars.Id = (int)(index != null ? index + 1 : 1);

            return _carRepository.Create(cars);
        }

        public Cars Update(Cars cars)
        {
            return _carRepository.Update(cars);
        }

        public Cars Delete(int id)
        {
            return _carRepository.Delete(id);
        }

        public Cars GetById(int id)
        {
            return _carRepository.GetById(id);
        }

        public IEnumerable<Cars> GetAll()
        {
            
            return _carRepository.GetAll();
        }
    }
}
