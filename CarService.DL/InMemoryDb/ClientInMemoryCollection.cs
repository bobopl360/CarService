using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.DL.InMemoryDb
{
    public class ClientInMemoryCollection
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
                },
                Service = new List<Service>()
                {
                    new Service
                    {
                        Id  = 1,
                        Name = "Water System Service",
                        Price = 150,
                        Type = Models.Enums.OrderType.Service,
                        Products = new List<Products>()
                        {           
                            new Products()
                            {
                                Id = 1,
                                Name = "Water Pump",
                                Price = 80
                            },
                            new Products()
                            {
                                Id = 2,
                                Name =  "Coolant fluid",
                                Price = 70
                            }
                        }
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
                },
                Service = new List<Service>()
                {
                    new Service
                    {
                        Id  = 1,
                        Name = "Water System Diagnosis",
                        Price = 80,
                        Type = Models.Enums.OrderType.Diagnosis,
                        Products = new List<Products>()
                        {
                            new Products()
                            {
                                Id = 1,
                                Name = "Diagnosis Tax",
                                Price = 80
                            }                         
                        }
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
                },
                Service = new List<Service>()
                {
                    new Service
                    {
                        Id  = 1,
                        Name = "Air Conditioner Not Working",
                        Price = 130,
                        Type = Models.Enums.OrderType.Consultation,
                        Products = new List<Products>()
                        {
                            new Products()
                            {
                                Id = 1,
                                Name = "Consultation Tax",
                                Price = 50
                            },
                            new Products()
                            {
                                Id = 2,
                                Name = "Air Conditioner Fluid",
                                Price = 80
                            }
                        }
                    }
                }
            },
        };
    }
}
