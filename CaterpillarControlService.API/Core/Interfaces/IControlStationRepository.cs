using CaterpillarControlService.API.Core.Models;

namespace CaterpillarControlService.API.Core.Interfaces
{
    public interface IControlStationRepository
    {
        Task<ControlStation> CreateControlStationAsync(ControlStation tollStation);
        Task<List<ControlStation>> GetAllAsync();
        Task<ControlStation?> GetByIdAsync(long id);
        Task<ControlStation?> UpdateAsync(long id, ControlStation tollStation);
        Task<ControlStation?> DeleteAsync(long id);
    }
}
