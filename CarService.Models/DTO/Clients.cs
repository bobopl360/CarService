using System.Collections.Generic;

namespace CarService.Models.DTO
{
    public class Clients
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Cars> Car { get; set; }

        public List<OrderItems> Order { get; set; }
    }
}
