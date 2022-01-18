using AutoMapper;
using CarService.BL.Interfaces;
using CarService.Models.DTO;
using CarService.Models.Requests;
using CarService.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carService;
        private readonly IMapper _mapper;

        public CarsController(ICarsService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _carService.GetById(id);

            if (result == null) return NotFound(id);
            var response = _mapper.Map<CarsResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateBill([FromBody] CarsRequest carRequest)
        {
            if (carRequest == null) return BadRequest();

            var cars = _mapper.Map<Cars>(carRequest);

            var result = _carService.Create(cars);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _carService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Cars cars)
        {
            if (cars == null) return BadRequest();

            var searchBill = _carService.GetById(cars.Id);

            if (searchBill == null) return NotFound(cars.Id);

            var result = _carService.Update(cars);

            return Ok(result);
        }

    }
}
