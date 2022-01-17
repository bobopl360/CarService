using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Requests
{
    public class ShiftRequest
    {
       
        public string Name { get; set; }

        public List<Employees> Employees { get; set; }
    }
}
