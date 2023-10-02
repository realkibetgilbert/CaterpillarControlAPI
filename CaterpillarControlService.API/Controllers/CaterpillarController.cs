using AutoMapper;
using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Core.Utils;
using CaterpillarControlService.API.Dtos.ControlStation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data;

namespace CaterpillarControlService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaterpillarController : ControllerBase
    {
        private readonly IControlStationRepository _controlStationRepository;
        private readonly IMapper _mapper;

        public CaterpillarController(IControlStationRepository controlStationRepository,IMapper mapper)
        {
            _controlStationRepository = controlStationRepository;
            _mapper = mapper;
        }
     


    }
}
