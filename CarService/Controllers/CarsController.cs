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
        public IActionResult CreateCar([FromBody] CarsRequest carRequest)
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
        public IActionResult Update([FromBody] CarsUpdateRequest carsRequest)
        {
            if (carsRequest == null) return BadRequest();

            var searchCar = _carService.GetById(carsRequest.Id);

            if (searchCar == null) return NotFound(carsRequest.Id);
            
            searchCar.Make = carsRequest.Make;

            var result = _carService.Update(searchCar);

            return Ok(result);
        }

    }
}
