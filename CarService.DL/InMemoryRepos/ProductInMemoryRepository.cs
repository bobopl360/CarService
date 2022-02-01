using CarService.DL.InMemoryDb;
using CarService.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CarService.DL.InMemoryRepos
{
    public class ProductInMemoryRepository : IProductRepository
    {
        public ProductInMemoryRepository()
        {

        }

        public Products Create(Products product)
        {
            ProductInMemoryCollection.ProductsDb.Add(product);

            return product;
        }

        public Products Delete(int id)
        {
            var product = ProductInMemoryCollection.ProductsDb.FirstOrDefault(product => product.Id == id);

            ProductInMemoryCollection.ProductsDb.Remove(product);

            return product;
        }

        public IEnumerable<Products> GetAll()
        {
            return ProductInMemoryCollection.ProductsDb;
        }

        public Products GetById(int id)
        {
            return ProductInMemoryCollection.ProductsDb.FirstOrDefault(x => x.Id == id);
        }

        public Products Update(Products product)
        {
            var result = ProductInMemoryCollection.ProductsDb.FirstOrDefault(x => x.Id == product.Id);

            result.Id = product.Id;
            result.Name = product.Name;
            result.Price = product.Price;

            return result;
        }
    }
}
