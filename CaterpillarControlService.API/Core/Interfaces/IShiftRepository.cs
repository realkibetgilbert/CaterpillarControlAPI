using CaterpillarControlService.API.Core.Models;

namespace CaterpillarControlService.API.Core.Interfaces
{
    public interface IShiftRepository
    {
        Task<List<Shift>> GetAllShiftsAsync();
    }
}
