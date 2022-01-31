using AutoMapper;
using CarService.BL.Interfaces;
using CarService.Models.DTO;
using CarService.Models.Requests;
using CarService.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductsService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _productService.GetById(id);

            if (result == null) return NotFound(id);
            var response = _mapper.Map<ProductResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateProduct([FromBody] ProductRequest productRequest)
        {
            if (productRequest == null) return BadRequest();

            var product = _mapper.Map<Products>(productRequest);

            var result = _productService.Create(product);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _productService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] ProductUpdateRequest productRequest)
        {
            if (productRequest == null) return BadRequest();

            var searchProduct = _productService.GetById(productRequest.Id);

            if (searchProduct == null) return NotFound(productRequest.Id);

            searchProduct.Name = productRequest.Name;

            var result = _productService.Update(searchProduct);

            return Ok(result);
        }
    }
}
