using CaterpillarControlService.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaterpillarControlService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftController(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        [HttpGet]
        [Route("get-shifts")]
        [Authorize(Roles ="Rider")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _shiftRepository.GetAllShiftsAsync());
        }
    }
}
