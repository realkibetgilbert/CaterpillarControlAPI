using AutoMapper;
using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Core.Utils;
using CaterpillarControlService.API.Dtos.ControlStation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaterpillarControlService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlStationController : ControllerBase
    {
        private readonly IControlStationRepository _controlStationRepository;
        private readonly IMapper _mapper;

        public ControlStationController(IControlStationRepository controlStationRepository, IMapper mapper)
        {
            _controlStationRepository = controlStationRepository;
            _mapper = mapper;
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Add(ControlStationToAddDto controlStationToAddDto)
        {
            var controlStationDomain = _mapper.Map<ControlStation>(controlStationToAddDto);

            await _controlStationRepository.CreateControlStationAsync(controlStationDomain);

            return Ok(_mapper.Map<ControlStationToDisplayDto>(controlStationDomain));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var controlStations = await _controlStationRepository.GetAllAsync();

            return Ok(controlStations);

        }

    }
}
