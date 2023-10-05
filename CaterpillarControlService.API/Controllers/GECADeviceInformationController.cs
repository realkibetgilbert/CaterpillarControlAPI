using CaterpillarControlService.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaterpillarControlService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GECADeviceInformationController : ControllerBase
    {
        private readonly IDeviceInformationRepository _deviceInformationRepository;

        public GECADeviceInformationController(IDeviceInformationRepository deviceInformationRepository)
        {
            _deviceInformationRepository = deviceInformationRepository;
        }
        [HttpGet]
        [Route("view-device-information")]
        [Authorize(Roles ="Rider")]
        public async Task<IActionResult> Get()
        {
            var devices= await _deviceInformationRepository.GetDeviceInformation();

            return Ok(devices);
        }
    }
}
