using CarService.Models.DTO;
using CarService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Responses
{
    public class ClientResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Cars> Car { get; set; }

        public PaymentType PaymentType { get; set; }

        public List<Service> Service { get; set; }
    }
}
