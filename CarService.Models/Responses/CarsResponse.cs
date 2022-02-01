using CarService.Models.Enums;

namespace CarService.Models.Responses
{
    public class CarsResponse
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public CarFuel Fuel { get; set; }
    }
}
