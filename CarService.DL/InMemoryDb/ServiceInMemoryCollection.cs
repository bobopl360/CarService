using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DL.InMemoryDb
{
    public class ServiceInMemoryCollection
    {
        public static List<Service> ServiceItemsDb = new List<Service>()
        {
            new Service()
            {
                Id = 1,
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
                        Name = "Coolant fluid",
                        Price = 70
                    }
                }
            },
            new Service()
            {
                Id = 2,
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
            },
            new Service()
            {
                Id = 3,
                Name = "Air Conditioner Not Working",
                Price = 130,
                Type = Models.Enums.OrderType.Diagnosis,
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
        };
    }
}
