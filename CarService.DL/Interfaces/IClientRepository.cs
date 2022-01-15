using CarService.Models.DTO;
using System.Collections.Generic;

namespace CarService.DL.InMemoryRepos
{
    public interface IClientRepository
    {
        Clients Create(Clients client);

        Clients Update(Clients client);

        Clients Delete(int id);

        Clients GetById(int id);

        IEnumerable<Clients> GetAll();
    }
}
