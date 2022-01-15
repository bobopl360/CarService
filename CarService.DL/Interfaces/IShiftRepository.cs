using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.DL.InMemoryRepos
{
    public interface IShiftRepository
    {
        Shift Create(Shift shift);

        Shift Update(Shift shift);

        Shift Delete(int id);

        Shift GetById(int id);

        IEnumerable<Shift> GetAll();
    }
}
