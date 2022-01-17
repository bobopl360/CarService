using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Requests
{
    public class ShiftUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Employees> Employees { get; set; }
    }
}
