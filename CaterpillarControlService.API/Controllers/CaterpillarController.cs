﻿using AutoMapper;
using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Core.Utils;
using CaterpillarControlService.API.Dtos.Caterpillar;
using CaterpillarControlService.API.Dtos.ControlStation;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using CaterpillarControlService.API.Infrastructure.SqlServerImplementations;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using static CaterpillarControlService.API.Core.Utils.Enums.Enumeration;

namespace CaterpillarControlService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaterpillarController : ControllerBase
    {
        private readonly ICaterpillarRepository _caterpillar;
        private readonly ICaterpillarRepository _caterpillarRepository;
        private readonly IPlanetRepository _planetRepository;
        private readonly IMapper _mapper;

        public CaterpillarController(ICaterpillarRepository caterpillarRepository, IPlanetRepository planetRepository, IMapper mapper)
        {
            _caterpillarRepository = caterpillarRepository;
            _planetRepository = planetRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]

        public async Task<IActionResult> Post(CaterpillarToCreateDto caterpillarToCreateDto)
        {
            var caterpillarDomain = _mapper.Map<Caterpillar>(caterpillarToCreateDto);

            await _caterpillarRepository.Add(caterpillarDomain);

            return Ok(_mapper.Map<CaterpillarToDisplayDto>(caterpillarDomain));
        }



        [HttpPatch("/caterpillars/{id}/move")]
        public async Task<IActionResult> MoveCaterpillar([FromRoute] long id, [FromBody] CaterpillarMovementDto movementDto)
        {

            var caterpillar = await _caterpillarRepository.GetCaterpillar(id);

            if (caterpillar == null)
            {
                var message = new
                {
                    title = "Not found",
                    message = "CaterpillarNotFound"
                };
                return StatusCode(StatusCodes.Status404NotFound, message);
            }

            var planet = await _planetRepository.GetById(1);

            bool isCrossingBoundary = _caterpillarRepository.IsCrossingBoundary(caterpillar, movementDto, planet);

            switch (movementDto.Direction)
            {
                case DirectionType.Up:
                    caterpillar.Y -= movementDto.Distance;
                    break;
                case DirectionType.Down:
                    caterpillar.Y += movementDto.Distance;
                    break;
                case DirectionType.Left:
                    caterpillar.X -= movementDto.Distance;
                    break;
                case DirectionType.Right:
                    caterpillar.X += movementDto.Distance;
                    break;
                default:
                    return BadRequest("Invalid direction.");
            }
            await _caterpillarRepository.UpdateCaterpillar(id, caterpillar);

            return StatusCode(StatusCodes.Status200OK, caterpillar);

        }
        [HttpPatch("/caterpillars/{id}/growshrink")]
        public async Task<IActionResult> GrowShrinkCaterpillar([FromRoute] long id, [FromBody] CaterpillarGrowShrinkDto caterpillarGrowShrinkDto)
        {

            var caterpillar = await _caterpillarRepository.GetCaterpillar(id);

            if (caterpillar == null)
            {
                var message = new
                {
                    title = "Not found",
                    message = "CaterpillarNotFound"
                };
                return StatusCode(StatusCodes.Status404NotFound, message);
            }
            switch (caterpillarGrowShrinkDto.GrowthOperation)
            {
                case GrowthOperation.Grow:
                    caterpillar.Length += caterpillarGrowShrinkDto.Length;
                    break;
                case GrowthOperation.Shrink:
                    caterpillar.Length -= caterpillarGrowShrinkDto.Length;
                    break;
                default:
                    return BadRequest("Invalid operation.");
            }

            await _caterpillarRepository.UpdateCaterpillar(id, caterpillar);

            return StatusCode(StatusCodes.Status200OK, caterpillar);

        }

    }
}
