using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.BL.Interfaces
{
    public interface IServiceService
    {
        Service Create(Service orderitem);

        Service Update(Service orderitem);

        Service Delete(int id);

        Service GetById(int id);

        IEnumerable<Service> GetAll();
    }
}
