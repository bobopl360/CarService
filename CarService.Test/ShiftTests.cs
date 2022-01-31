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
    public class ShiftTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IShiftRepository> _shiftRepository;
        private readonly IShiftsService _shiftService;
        private readonly ShiftController _shiftController;

        private IList<Shift> Shifts = new List<Shift>()
        {
            {new Shift()
                {
                    Id = 1,
                    Name = "Ivan",
                    Employees = new List<Employees>()
                }
            }, new Shift()
                {
                    Id = 2,
                    Name = "Petko",
                    Employees = new List<Employees>()
            }
        };

        public ShiftTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _shiftRepository = new Mock<IShiftRepository>();

            var logger = new Mock<ILogger>();

            _shiftService = new ShiftService(_shiftRepository.Object, logger.Object);

            _shiftController = new ShiftController(_shiftService, _mapper);
        }

        [Fact]
        public void Shift_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IShiftsService>();

            mockedService.Setup(x => x.GetAll()).Returns(Shifts);

            //inject
            var controller = new ShiftController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var shifts = okObjectResult.Value as IEnumerable<Shift>;
            Assert.NotNull(shifts);
            Assert.Equal(expectedCount, shifts.Count());
        }

        [Fact]
        public void Shift_GetById_NameCheck()
        {
            //setup
            var shiftId = 2;
            var expectedName = "Petko";

            _shiftRepository.Setup(x => x.GetById(shiftId))
                .Returns(Shifts.FirstOrDefault(t => t.Id == shiftId));

            //Act
            var result = _shiftController.GetById(shiftId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as ShiftResponse;
            var shift = _mapper.Map<Shift>(response);

            Assert.NotNull(shift);
            Assert.Equal(expectedName, shift.Name);
        }

        [Fact]
        public void Shift_GetById_NotFound()
        {
            //setup
            var shiftId = 3;

            _shiftRepository.Setup(x => x.GetById(shiftId))
                .Returns(Shifts.FirstOrDefault(t => t.Id == shiftId));

            //Act
            var result = _shiftController.GetById(shiftId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(shiftId, response);
        }

        [Fact]
        public void Shift_Update_ShiftName()
        {
            var shiftId = 1;
            var expectedName = "Updated Shift Name";

            var shift = Shifts.FirstOrDefault(x => x.Id == shiftId);
            shift.Name = expectedName;

            _shiftRepository.Setup(x => x.GetById(shiftId))
                .Returns(Shifts.FirstOrDefault(t => t.Id == shiftId));
            _shiftRepository.Setup(x => x.Update(shift))
                .Returns(shift);

            //Act
            var shiftUpdateRequest = _mapper.Map<ShiftUpdateRequest>(shift);
            var result = _shiftController.Update(shiftUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Shift;
            Assert.NotNull(val);
            Assert.Equal(expectedName, val.Name);

        }

        [Fact]
        public void Shift_Delete_ExistingShift()
        {
            //Setup
            var shiftId = 1;

            var shift = Shifts.FirstOrDefault(x => x.Id == shiftId);

            _shiftRepository.Setup(x => x.Delete(shiftId)).Callback(() => Shifts.Remove(shift)).Returns(shift);

            //Act
            var result = _shiftController.Delete(shiftId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Shift;
            Assert.NotNull(val);
            Assert.Equal(1, Shifts.Count);
            Assert.Null(Shifts.FirstOrDefault(x => x.Id == shiftId));
        }

        [Fact]
        public void Shift_Delete_NotExisting_Shift()
        {
            //Setup
            var shiftId = 3;

            var shift = Shifts.FirstOrDefault(x => x.Id == shiftId);

            _shiftRepository.Setup(x => x.Delete(shiftId)).Callback(() => Shifts.Remove(shift)).Returns(shift);

            //Act
            var result = _shiftController.Delete(shiftId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(shiftId, response);
        }

        [Fact]
        public void Shift_CreateShift()
        {
            //setup
            var shift = new Shift()
            {
                Id = 3,
                Name = "Name 3"
            };

            _shiftRepository.Setup(x => x.GetAll()).Returns(Shifts);

            _shiftRepository.Setup(x => x.Create(It.IsAny<Shift>())).Callback(() =>
            {
                Shifts.Add(shift);
            }).Returns(shift);

            //Act
            var result = _shiftController.CreateShift(_mapper.Map<ShiftRequest>(shift));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Shifts.FirstOrDefault(x => x.Id == shift.Id));
            Assert.Equal(3, Shifts.Count);

        }
    }
}
