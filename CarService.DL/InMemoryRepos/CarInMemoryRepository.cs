using CarService.DL.InMemoryDb;
using CarService.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CarService.DL.InMemoryRepos
{
    class CarInMemoryRepository : ICarRepository
    {
        public CarInMemoryRepository()
        {

        }

        public Cars Create(Cars cars)
        {
            CarInMemoryCollection.CarsDb.Add(cars);
            
            return cars;
        }

        public Cars Delete(int id)
        {
            var cars = CarInMemoryCollection.CarsDb.FirstOrDefault(cars => cars.Id == id);

            CarInMemoryCollection.CarsDb.Remove(cars);

            return cars;
        }

        public IEnumerable<Cars> GetAll()
        {
            return CarInMemoryCollection.CarsDb;
        }

        public Cars GetById(int id)
        {
            return CarInMemoryCollection.CarsDb.FirstOrDefault(x => x.Id == id);
        }

        public Cars Update(Cars cars)
        {
            var result = CarInMemoryCollection.CarsDb.FirstOrDefault(x => x.Id == cars.Id);

            result.Make = cars.Make;
            result.Model = cars.Model;
            result.Fuel = cars.Fuel;

            return result;
        }
    }
}
