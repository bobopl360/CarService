using CarService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Requests
{
    public class EmployeeRequest
    {
       
        public string Name { get; set; }

        public double MonthlySalary { get; set; }

        public PaymentType paymentType { get; set; }
    }
}
