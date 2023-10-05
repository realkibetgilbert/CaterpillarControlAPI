using CaterpillarControlService.API.Core.Models;

namespace CaterpillarControlService.API.Core.Interfaces
{
    public interface IDeviceInformationRepository
    {
       Task<List<DeviceInformation>> GetDeviceInformation();
    }
}
