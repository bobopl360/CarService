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
    public class CarsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICarRepository> _carRepository;
        private readonly ICarsService _carService;
        private readonly CarsController _carController;

        private IList<Cars> Cars = new List<Cars>()
        {
            new Cars() { Id = 1, Make = "Car1", Model = "Model1", Fuel = Models.Enums.CarFuel.Petrol},
            new Cars() { Id = 2, Make = "Car2", Model = "Model2", Fuel = Models.Enums.CarFuel.Diesel},
        };

        public CarsTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _carRepository = new Mock<ICarRepository>();

            var logger = new Mock<ILogger>();

            _carService = new CarsService(_carRepository.Object, logger.Object);

            _carController = new CarsController(_carService, _mapper);
        }

        [Fact]
        public void Cars_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<ICarsService>();

            mockedService.Setup(x => x.GetAll()).Returns(Cars);

            //inject
            var controller = new CarsController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var cars = okObjectResult.Value as IEnumerable<Cars>;
            Assert.NotNull(cars);
            Assert.Equal(expectedCount, cars.Count());
        }

        [Fact]
        public void Cars_GetById_ModelCheck()
        {
            //setup
            var carId = 2;
            var expectedModel = "Model2";

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));

            //Act
            var result = _carController.GetById(carId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as CarsResponse;
            var car = _mapper.Map<Cars>(response);

            Assert.NotNull(car);
            Assert.Equal(expectedModel, car.Model);
        }

        [Fact]
        public void Cars_GetById_NotFound()
        {
            //setup
            var carId = 3;

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));

            //Act
            var result = _carController.GetById(carId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(carId, response);
        }

        [Fact]
        public void Cars_Update_CarsModel()
        {
            var carId = 1;
            var expectedModel = "Updated Car Model";

            var car = Cars.FirstOrDefault(x => x.Id == carId);
            car.Model = expectedModel;

            _carRepository.Setup(x => x.GetById(carId))
                .Returns(Cars.FirstOrDefault(t => t.Id == carId));
            _carRepository.Setup(x => x.Update(car))
                .Returns(car);

            //Act
            var carUpdateRequest = _mapper.Map<CarsUpdateRequest>(car);
            var result = _carController.Update(carUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Cars;
            Assert.NotNull(val);
            Assert.Equal(expectedModel, val.Model);

        }

        [Fact]
        public void Cars_Delete_ExistingCars()
        {
            //Setup
            var carId = 1;

            var car = Cars.FirstOrDefault(x => x.Id == carId);

            _carRepository.Setup(x => x.Delete(carId)).Callback(() => Cars.Remove(car)).Returns(car);

            //Act
            var result = _carController.Delete(carId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Cars;
            Assert.NotNull(val);
            Assert.Equal(1, Cars.Count);
            Assert.Null(Cars.FirstOrDefault(x => x.Id == carId));
        }

        [Fact]
        public void Cars_Delete_NotExisting_Cars()
        {
            //Setup
            var carId = 3;

            var car = Cars.FirstOrDefault(x => x.Id == carId);

            _carRepository.Setup(x => x.Delete(carId)).Callback(() => Cars.Remove(car)).Returns(car);

            //Act
            var result = _carController.Delete(carId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(carId, response);
        }

        [Fact]
        public void Cars_CreateCars()
        {
            //setup
            var car = new Cars()
            {
                Id = 3,
                Make = "Car3",
                Model = "Model3",
                Fuel = Models.Enums.CarFuel.Electric
            };

            _carRepository.Setup(x => x.GetAll()).Returns(Cars);

            _carRepository.Setup(x => x.Create(It.IsAny<Cars>())).Callback(() =>
            {
                Cars.Add(car);
            }).Returns(car);

            //Act
            var result = _carController.CreateCar(_mapper.Map<CarsRequest>(car));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Cars.FirstOrDefault(x => x.Id == car.Id));
            Assert.Equal(3, Cars.Count);

        }

    }
}

