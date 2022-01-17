using CarService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double MonthlySalary { get; set; }

        public PaymentType paymentType { get; set; }
    }
}
