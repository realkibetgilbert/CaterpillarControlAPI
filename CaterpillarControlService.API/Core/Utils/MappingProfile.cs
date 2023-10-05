using AutoMapper;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Dtos.Auth;
using CaterpillarControlService.API.Dtos.Caterpillar;
using CaterpillarControlService.API.Dtos.ControlStation;

namespace CaterpillarControlService.API.Core.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ControlStationToAddDto, ControlStation>().ReverseMap();

            CreateMap<ControlStation, ControlStationToDisplayDto>().ReverseMap();

            CreateMap<ControlStationToUpdateDto, ControlStation>().ReverseMap();

            CreateMap<CaterpillarToCreateDto, Caterpillar>().ReverseMap();

            CreateMap<Caterpillar, CaterpillarToDisplayDto>().ReverseMap();

            CreateMap<User, RiderToDisplayDto>().ReverseMap();
 

        }
    }
}
