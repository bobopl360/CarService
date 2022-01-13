using CarService.Models.Enums;

namespace CarService.Models.DTO
{
    public class Cars
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public CarFuel Fuel { get; set; }
    }
}
