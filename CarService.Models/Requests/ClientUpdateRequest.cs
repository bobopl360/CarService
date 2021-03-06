using CarService.Models.DTO;
using CarService.Models.Enums;
using System.Collections.Generic;

namespace CarService.Models.Requests
{
    public class ClientUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Cars> Car { get; set; }

        public PaymentType PaymentType { get; set; }

        public List<Service> Service { get; set; }
    }
}
