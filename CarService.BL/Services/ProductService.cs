using CarService.BL.Interfaces;
using CarService.DL.InMemoryRepos;
using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarService.BL.Services
{
    public class ProductService : IProductsService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Products Create(Products product)
        {
            return _productRepository.Create(product);
        }

        public Products Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Products> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Products GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Products Update(Products product)
        {
            var index = _productRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            product.Id = (int)(index != null ? index + 1 : 1);

            return _productRepository.Create(product);
        }
    }
}
