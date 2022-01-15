using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.DL.InMemoryDb
{
    public  class CarInMemoryCollection
    {
        public static List<Cars> CarsDb = new List<Cars>()
        {
            new Cars()
            {
                Id = 1,
                Make = "Mercedes",
                Model = "C class",
                Fuel = Models.Enums.CarFuel.Petrol
            },

            new Cars()
            {
                Id = 2,
                Make = "BMW",
                Model = "5 Series",
                Fuel = Models.Enums.CarFuel.Diesel
            },
            new Cars()
            {
                Id = 3,
                Make = "Tesla",
                Model = "Model S",
                Fuel = Models.Enums.CarFuel.Electric
            }
        };
    }
}
