using CarService.BL.Interfaces;
using CarService.DL.InMemoryRepos;
using CarService.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CarService.BL.Services
{
    public class ShiftService : IShiftsService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }
        public Shift Create(Shift shift)
        {
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
            var index = _shiftRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            shift.Id = (int)(index != null ? index + 1 : 1);

            return _shiftRepository.Create(shift);
        }
    }
}
