using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Responses
{
    public class ShiftResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Employees> Employees { get; set; }
    }
}
