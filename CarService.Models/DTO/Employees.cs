using CarService.Models.Enums;
using System.Collections.Generic;

namespace CarService.Models.DTO
{
    public class Employees
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double MonthlySalary { get; set; }

        public  PaymentType paymentType { get; set; }
    }
}

