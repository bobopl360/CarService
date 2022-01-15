using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.DL.InMemoryRepos
{
    public interface IEmployeeRepository
    {
        Employees Create(Employees employee);

        Employees Update(Employees employee);

        Employees Delete(int id);

        Employees GetById(int id);

        IEnumerable<Employees> GetAll();
    }
}
