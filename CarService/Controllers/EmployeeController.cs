using AutoMapper;
using CarService.BL.Interfaces;
using CarService.Models.Requests;
using CarService.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Models.DTO;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _employeeService.GetById(id);

            if (result == null) return NotFound(id);
            var response = _mapper.Map<EmployeeResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult CreateEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            if (employeeRequest == null) return BadRequest();

            var employee = _mapper.Map<Employees>(employeeRequest);

            var result = _employeeService.Create(employee);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _employeeService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] Employees employees)
        {
            if (employees == null) return BadRequest();

            var searchBill = _employeeService.GetById(employees.Id);

            if (searchBill == null) return NotFound(employees.Id);

            var result = _employeeService.Update(employees);

            return Ok(result);
        }
    }
}
