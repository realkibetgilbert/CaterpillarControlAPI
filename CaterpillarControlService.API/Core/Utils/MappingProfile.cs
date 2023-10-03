﻿using AutoMapper;
using CaterpillarControlService.API.Core.Models;
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
        }
    }
}