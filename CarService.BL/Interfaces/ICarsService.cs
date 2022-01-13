using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.BL.Interfaces
{
    public interface ICarsService
    {
        Cars Create(Cars cars);
        
        Cars Update(Cars cars);

        Cars Delete(int id);

        Cars GetById(int id);

        IEnumerable<Cars> GetAll();
    }
}
