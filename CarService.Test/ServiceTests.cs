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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace CarService.Test
{
    public class ServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IServiceRepository> _serviceRepository;
        private readonly IServiceService _serviceService;
        private readonly ServiceController _serviceController;

        private IList<Service> Services = new List<Service>()
        {
            {new Service() {Id = 1, Name = "TestName", Price = 3}},
            {new() {Id = 2, Name = "AnotherName", Price = 4.5}}
        };

        public ServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _serviceRepository = new Mock<IServiceRepository>();

            var logger = new Mock<ILogger>();

            _serviceService = new ServiceService(_serviceRepository.Object, logger.Object);

            _serviceController = new ServiceController(_serviceService, _mapper);
        }

        [Fact]
        public void Service_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IServiceService>();

            mockedService.Setup(x => x.GetAll()).Returns(Services);

            //inject
            var controller = new ServiceController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var services = okObjectResult.Value as IEnumerable<Service>;
            Assert.NotNull(services);
            Assert.Equal(expectedCount, services.Count());
        }

        [Fact]
        public void Service_GetById_NameCheck()
        {
            //setup
            var serviceId = 2;
            var expectedName = "AnotherName";

            _serviceRepository.Setup(x => x.GetById(serviceId))
                .Returns(Services.FirstOrDefault(t => t.Id == serviceId));

            //Act
            var result = _serviceController.GetById(serviceId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as ServiceResponse;
            var service = _mapper.Map<Service>(response);

            Assert.NotNull(service);
            Assert.Equal(expectedName, service.Name);
        }

        [Fact]
        public void Service_GetById_PriceCheck()
        {
            //setup
            var serviceId = 2;
            var expectedPrice = 4.5;

            _serviceRepository.Setup(x => x.GetById(serviceId))
                .Returns(Services.FirstOrDefault(t => t.Id == serviceId));

            //Act
            var result = _serviceController.GetById(serviceId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as ServiceResponse;
            var service = _mapper.Map<Service>(response);

            Assert.NotNull(service);
            Assert.Equal(expectedPrice, service.Price);
        }


        [Fact]
        public void Service_GetById_NotFound()
        {
            //setup
            var serviceId = 3;

            _serviceRepository.Setup(x => x.GetById(serviceId))
                .Returns(Services.FirstOrDefault(t => t.Id == serviceId));

            //Act
            var result = _serviceController.GetById(serviceId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(serviceId, response);
        }

        [Fact]
        public void Service_Update_ServiceName()
        {
            var serviceId = 1;
            var expectedName = "Updated Service Name";

            var service = Services.FirstOrDefault(x => x.Id == serviceId);
            service.Name = expectedName;

            _serviceRepository.Setup(x => x.GetById(serviceId))
                .Returns(Services.FirstOrDefault(t => t.Id == serviceId));
            _serviceRepository.Setup(x => x.Update(service))
                .Returns(service);

            //Act
            var serviceUpdateRequest = _mapper.Map<ServiceUpdateRequest>(service);
            var result = _serviceController.Update(serviceUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Service;
            Assert.NotNull(val);
            Assert.Equal(expectedName, val.Name);

        }

        [Fact]
        public void Service_Delete_ExistingService()
        {
            //Setup
            var serviceId = 1;

            var service = Services.FirstOrDefault(x => x.Id == serviceId);

            _serviceRepository.Setup(x => x.Delete(serviceId)).Callback(() => Services.Remove(service)).Returns(service);

            //Act
            var result = _serviceController.Delete(serviceId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Service;
            Assert.NotNull(val);
            Assert.Equal(1, Services.Count);
            Assert.Null(Services.FirstOrDefault(x => x.Id == serviceId));
        }

        [Fact]
        public void Service_Delete_NotExisting_Service()
        {
            //Setup
            var serviceId = 3;

            var service = Services.FirstOrDefault(x => x.Id == serviceId);

            _serviceRepository.Setup(x => x.Delete(serviceId)).Callback(() => Services.Remove(service)).Returns(service);

            //Act
            var result = _serviceController.Delete(serviceId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(serviceId, response);
        }

        [Fact]
        public void Service_CreateService()
        {
            //setup
            var service = new Service()
            {
                Id = 3,
                Name = "Name 3"
            };

            _serviceRepository.Setup(x => x.GetAll()).Returns(Services);

            _serviceRepository.Setup(x => x.Create(It.IsAny<Service>())).Callback(() =>
            {
                Services.Add(service);
            }).Returns(service);

            //Act
            var result = _serviceController.CreateService(_mapper.Map<ServiceRequest>(service));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Services.FirstOrDefault(x => x.Id == service.Id));
            Assert.Equal(3, Services.Count);

        }

    }
}
