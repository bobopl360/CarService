using CarService.Models.DTO;
using CarService.Models.Enums;
using System.Collections.Generic;

namespace CarService.Models.Responses
{
    public class ServiceResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public OrderType Type { get; set; }

        public List<Products> Products { get; set; }
    }
}
