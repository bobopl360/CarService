using CarService.BL.Interfaces;
using CarService.DL.InMemoryRepos;
using CarService.Models.DTO;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace CarService.BL.Services
{
    public class ShiftService : IShiftsService
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly ILogger _logger;

        public ShiftService(IShiftRepository shiftRepository, ILogger logger)
        {
            _shiftRepository = shiftRepository;
            _logger = logger;
        }
        public Shift Create(Shift shift)
        {
            var index = _shiftRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            shift.Id = (int)(index != null ? index + 1 : 1);

            return _shiftRepository.Create(shift);
        }

        public Shift Delete(int id)
        {
            return _shiftRepository.Delete(id);
        }

        public IEnumerable<Shift> GetAll()
        {
            return _shiftRepository.GetAll();
        }

        public Shift GetById(int id)
        {
            return _shiftRepository.GetById(id);
        }

        public Shift Update(Shift shift)
        {

            return _shiftRepository.Update(shift);
        }
    }
}
