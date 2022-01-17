using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.BL.Interfaces
{
    public interface IShiftsService
    {
        Shift Create(Shift shift);

        Shift Update(Shift shift);

        Shift Delete(int id);

        Shift GetById(int id);

        IEnumerable<Shift> GetAll();
    }
}
