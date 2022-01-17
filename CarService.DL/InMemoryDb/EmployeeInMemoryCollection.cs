using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DL.InMemoryDb
{
    public class EmployeeInMemoryCollection
    {
        public static List<Employees> EmployeeDb = new List<Employees>
        {
            new Employees()
            {
                Id = 1,
                Name = "Petko",
                MonthlySalary = 1200,
                paymentType = Models.Enums.PaymentType.Cash
            },
            new Employees()
            {
                Id = 2,
                Name = "Ivaylo",
                MonthlySalary = 1400,
                paymentType = Models.Enums.PaymentType.CreditCard
            },
            new Employees()
            {
                Id = 3,
                Name = "Georgi",
                MonthlySalary = 1000,
                paymentType = Models.Enums.PaymentType.Cash
            }
        };
    }
}
