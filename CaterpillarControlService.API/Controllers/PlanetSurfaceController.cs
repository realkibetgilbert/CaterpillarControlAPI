using CaterpillarControlService.API.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace CaterpillarControlService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetSurfaceController : ControllerBase
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetSurfaceController(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        [HttpGet]
        [Route("planet-details")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _planetRepository.GetPlanets());  
        }
    }
}
