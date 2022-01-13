using System.Collections.Generic;
using CarService.Models.DTO;

namespace CarService.BL.Interfaces
{
    public interface IEmployeeService
    {
        Employees Create(Employees employee);

        Employees Update(Employees employee);

        Employees Delete(int id);

        Employees GetById(int id);

        IEnumerable<Employees> GetAll();
    }
}
