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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _serviceService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _serviceService.GetById(id);

            if (result == null) return NotFound(id);
            var response = _mapper.Map<ServiceResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateService([FromBody] ServiceRequest serviceRequest)
        {
            if (serviceRequest == null) return BadRequest();

            var service = _mapper.Map<Service>(serviceRequest);

            var result = _serviceService.Create(service);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _serviceService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Service service)
        {
            if (service == null) return BadRequest();

            var searchService = _serviceService.GetById(service.Id);

            if (searchService == null) return NotFound(service.Id);

            var result = _serviceService.Update(service);

            return Ok(result);
        }
    }
}
