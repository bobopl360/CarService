using CarService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Responses
{
    public class CarsResponse
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public CarFuel Fuel { get; set; }
    }
}
