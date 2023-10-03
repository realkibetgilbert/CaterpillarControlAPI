using CaterpillarControlService.API.Core.Models;

namespace CaterpillarControlService.API.Core.Interfaces
{
    public interface IPlanetRepository
    {
        Task<Planet?> GetById(long id);
    }
}
