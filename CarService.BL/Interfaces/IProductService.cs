using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.BL.Interfaces
{
    public interface IProductsService
    {
        Products Create(Products product);

        Products Update(Products product);

        Products Delete(int id);

        Products GetById(int id);

        IEnumerable<Products> GetAll();
    }
    
}
