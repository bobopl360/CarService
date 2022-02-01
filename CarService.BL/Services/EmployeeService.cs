using CarService.BL.Interfaces;
using CarService.DL.InMemoryRepos;
using CarService.Models.DTO;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace CarService.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public Employees Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        public IEnumerable<Employees> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employees GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public Employees Update(Employees employee)
        {
            return _employeeRepository.Update(employee);
        }

        public Employees Create(Employees employee)
        {
            var index = _employeeRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            employee.Id = (int)(index != null ? index + 1 : 1);

            return _employeeRepository.Create(employee);
        }
    }
}
