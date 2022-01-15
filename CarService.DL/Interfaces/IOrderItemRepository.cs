using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.DL.InMemoryRepos
{
    public interface IOrderItemRepository
    {
        OrderItems Create(OrderItems orderitem);

        OrderItems Update(OrderItems orderitem);

        OrderItems Delete(int id);

        OrderItems GetById(int id);

        IEnumerable<OrderItems> GetAll();
    }
}
