using AutoMapper;
using CarService.BL.Interfaces;
using CarService.BL.Services;
using CarService.Controllers;
using CarService.DL.InMemoryRepos;
using CarService.Extensions;
using CarService.Models.DTO;
using CarService.Models.Requests;
using CarService.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Test
{
    public class EmployeeTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private readonly IEmployeeService _employeeService;
        private readonly EmployeeController _employeeController;

        private IList<Employees> Employees = new List<Employees>()
        {
            new Employees()
            {
                Id = 1,
                Name = "Ivan",
                MonthlySalary = 1200,
                paymentType = Models.Enums.PaymentType.Cash

            },
            new Employees()
        {
            Id = 2,
            Name = "Dragan",
            MonthlySalary = 1100,
            paymentType = Models.Enums.PaymentType.CreditCard
        } };

        public EmployeeTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            _mapper = mockMapper.CreateMapper();

            _employeeRepository = new Mock<IEmployeeRepository>();

            var logger = new Mock<ILogger>();

            _employeeService = new EmployeeService(_employeeRepository.Object);
            _employeeController = new EmployeeController(_employeeService, _mapper);

        }
        [Fact]
        public void Employee_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IEmployeeService>();

            mockedService.Setup(x => x.GetAll()).Returns(Employees);

            //inject
            var controller = new EmployeeController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var employees = okObjectResult.Value as IEnumerable<Employees>;
            Assert.NotNull(employees);
            Assert.Equal(expectedCount, employees.Count());
        }

        [Fact]
        public void Employee_GetById_NameCheck()
        {
            //setup
            var employeeId = 2;
            var expectedName = "Dragan";

            _employeeRepository.Setup(x => x.GetById(employeeId))
                .Returns(Employees.FirstOrDefault(e => e.Id == employeeId));

            //Act
            var result = _employeeController.GetById(employeeId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as EmployeeResponse;
            var employee = _mapper.Map<Employees>(response);

            Assert.NotNull(employee);
            Assert.Equal(expectedName, employee.Name);
        }

        [Fact]
        public void Employee_GetById_NotFound()
        {
            //setup
            var employeeId = 3;

            _employeeRepository.Setup(x => x.GetById(employeeId))
                .Returns(Employees.FirstOrDefault(t => t.Id == employeeId));

            //Act
            var result = _employeeController.GetById(employeeId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(employeeId, response);
        }

        [Fact]
        public void Employee_Update_EmployeeName()
        {
            var employeeId = 1;
            var expectedName = "Updated Employee Name";

            var employee = Employees.FirstOrDefault(x => x.Id == employeeId);
            employee.Name = expectedName;

            _employeeRepository.Setup(x => x.GetById(employeeId))
                .Returns(Employees.FirstOrDefault(t => t.Id == employeeId));
            _employeeRepository.Setup(x => x.Update(employee))
                .Returns(employee);

            //Act
            var employeeUpdateRequest = _mapper.Map<EmployeeUpdateRequest>(employee);
            var result = _employeeController.Update(employeeUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Employees;
            Assert.NotNull(val);
            Assert.Equal(expectedName, val.Name);

        }

        [Fact]
        public void Employee_Delete_ExistingEmployee()
        {
            //Setup
            var employeeId = 1;

            var employee = Employees.FirstOrDefault(x => x.Id == employeeId);

            _employeeRepository.Setup(x => x.Delete(employeeId)).Callback(() => Employees.Remove(employee)).Returns(employee);

            //Act
            var result = _employeeController.Delete(employeeId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Employees;
            Assert.NotNull(val);
            Assert.Equal(1, Employees.Count);
            Assert.Null(Employees.FirstOrDefault(x => x.Id == employeeId));
        }

        [Fact]
        public void Employee_Delete_NotExisting_Employee()
        {
            //Setup
            var employeeId = 3;

            var employee = Employees.FirstOrDefault(x => x.Id == employeeId);

            _employeeRepository.Setup(x => x.Delete(employeeId)).Callback(() => Employees.Remove(employee)).Returns(employee);

            //Act
            var result = _employeeController.Delete(employeeId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(employeeId, response);
        }

        [Fact]
        public void Employee_CreateEmployee()
        {
            //setup
            var employee = new Employees()
            {
                Id = 3,
                Name = "Stoyan",
                MonthlySalary = 1111,
                paymentType = Models.Enums.PaymentType.Cash
            };

            _employeeRepository.Setup(x => x.GetAll()).Returns(Employees);

            _employeeRepository.Setup(x => x.Create(It.IsAny<Employees>())).Callback(() =>
            {
                Employees.Add(employee);
            }).Returns(employee);

            //Act
            var result = _employeeController.CreateEmployee(_mapper.Map<EmployeeRequest>(employee));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Employees.FirstOrDefault(x => x.Id == employee.Id));
            Assert.Equal(3, Employees.Count);

        }
    }
}
