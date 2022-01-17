using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DL.InMemoryDb
{
    public class ShiftInMemoryCollection
    {
        public static List<Shift> ShiftDb = new List<Shift>()
        {
            new Shift()
            {
                Id = 1,
                Name = "Day Shift",
                Employees = new List<Employees>()
                {
                    new Employees()
                    {
                        Id = 1,
                        Name = "Ivaylo",
                        MonthlySalary = 1400,
                        paymentType = Models.Enums.PaymentType.CreditCard
                    },
                    new Employees()
                    {
                        Id = 2,
                        Name = "Georgi",
                        MonthlySalary = 1000,
                        paymentType = Models.Enums.PaymentType.Cash
                    }
                }

            },
            new Shift()
            {
                Id = 2,
                Name = "Night Shift",
                Employees = new List<Employees>()
                {
                    new Employees()
                    {
                        Id = 1,
                        Name = "Petko",
                        MonthlySalary = 1200,
                        paymentType = Models.Enums.PaymentType.Cash
                    }
                }
            }
        };
    }
}
