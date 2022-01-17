using CarService.Models.DTO;
using CarService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Requests
{
    public class ServiceRequest
    {
       
        public string Name { get; set; }

        public double Price { get; set; }

        public OrderType Type { get; set; }

        public List<Products> Products { get; set; }
    }
}
