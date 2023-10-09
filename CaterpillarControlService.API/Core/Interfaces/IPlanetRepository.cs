using CaterpillarControlService.API.Core.Models;

namespace CaterpillarControlService.API.Core.Interfaces
{
    public interface IPlanetRepository
    {
        Task<List<Planet>> GetPlanets();
        Task<Planet> GetPlanetById(long id);
    }
}
