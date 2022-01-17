using CarService.DL.InMemoryDb;
using CarService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarService.DL.InMemoryRepos
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
    {

        public EmployeeInMemoryRepository()
        {

        }

        public Employees Create(Employees employee)
        {
            EmployeeInMemoryCollection.EmployeeDb.Add(employee);

            return employee;
        }

        public Employees Delete(int id)
        {
            var employee = EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(employee => employee.Id == id);

            EmployeeInMemoryCollection.EmployeeDb.Remove(employee);

            return employee;
        }

        public IEnumerable<Employees> GetAll()
        {
            return EmployeeInMemoryCollection.EmployeeDb;
        }

        public Employees GetById(int id)
        {
            return EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(x => x.Id == id); 
        }

        public Employees Update(Employees employee)
        {
            var result = EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(x => x.Id == employee.Id);

            result.Name = employee.Name;
            result.MonthlySalary = employee.MonthlySalary;
            result.paymentType = employee.paymentType;

            return result;
        }
    }
}
