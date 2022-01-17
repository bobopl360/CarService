using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DL.InMemoryDb
{
    public class ProductInMemoryCollection
    {
        public static List<Products> ProductsDb = new List<Products>()
        {
            new Products()
            {
                Id = 1,
                Name = "Diagnosis Tax",
                Price = 80
            },
            new Products()
            {
                Id = 2,
                Name = "Consultation Tax",
                Price = 50
            }
        };
    }
}
