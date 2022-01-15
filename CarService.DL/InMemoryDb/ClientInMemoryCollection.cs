using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DL.InMemoryDb
{
    class ClientInMemoryCollection
    {
        public static List<Clients> ClientsDb = new List<Clients>()
        {
            new Clients()
            {
                Id  =   1,
                Name = "Ivan",
                PaymentType = Models.Enums.PaymentType.Cash,
                Car = new List<Cars>()
                {
                    new Cars()
                    {
                        Id  = 1,
                        Make = "Merceses",
                        Model = "S class",
                        Fuel = Models.Enums.CarFuel.Diesel
                    }
                }
            },
            new Clients()
            {
                Id  =   2,
                Name = "Petko",
                PaymentType = Models.Enums.PaymentType.CreditCard,
                Car = new List<Cars>()
                {
                    new Cars()
                    {
                        Id  = 2,
                        Make = "VW",
                        Model = "Passat",
                        Fuel = Models.Enums.CarFuel.Petrol
                    }
                }
            },
            new Clients()
            {
                Id  =   3,
                Name = "Dimitur",
                PaymentType = Models.Enums.PaymentType.Cash,
                Car = new List<Cars>()
                {
                    new Cars()
                    {
                        Id  = 3,
                        Make = "Toyota",
                        Model = "Prius",
                        Fuel = Models.Enums.CarFuel.Hybrid
                    }
                }
            },
        };
    }
}
