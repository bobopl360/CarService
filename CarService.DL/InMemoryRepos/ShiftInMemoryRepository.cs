using CarService.DL.InMemoryDb;
using CarService.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CarService.DL.InMemoryRepos
{
    public class ShiftInMemoryRepository : IShiftRepository
    {
        public ShiftInMemoryRepository()
        {

        }

        public Shift Create(Shift shift)
        {
            ShiftInMemoryCollection.ShiftDb.Add(shift);

            return shift;
        }

        public Shift Delete(int id)
        {
            var shift = ShiftInMemoryCollection.ShiftDb.FirstOrDefault(shift => shift.Id == id);

            ShiftInMemoryCollection.ShiftDb.Remove(shift);

            return shift;
        }

        public IEnumerable<Shift> GetAll()
        {
            return ShiftInMemoryCollection.ShiftDb;
        }

        public Shift GetById(int id)
        {
           return ShiftInMemoryCollection.ShiftDb.FirstOrDefault(x => x.Id == id);
        }

        public Shift Update(Shift shift)
        {
           var result = ShiftInMemoryCollection.ShiftDb.FirstOrDefault(x => x.Id == shift.Id);

            result.Id = shift.Id;
            result.Name = shift.Name;
            result.Employees = shift.Employees;

            return result;
        }
    }
}
