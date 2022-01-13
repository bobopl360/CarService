using System.Collections.Generic;

namespace CarService.Models.DTO
{
    public class Shift
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Employees> Employees { get; set; }
    }
}
