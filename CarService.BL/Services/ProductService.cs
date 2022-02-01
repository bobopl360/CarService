using CarService.BL.Interfaces;
using CarService.DL.InMemoryRepos;
using CarService.Models.DTO;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace CarService.BL.Services
{
    public class ProductService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public ProductService(IProductRepository productRepository, ILogger logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public Products Create(Products product)
        {
            var index = _productRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            product.Id = (int)(index != null ? index + 1 : 1);
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
            return _productRepository.Update(product);
        }
    }
}
