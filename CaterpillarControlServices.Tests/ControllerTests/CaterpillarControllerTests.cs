using AutoMapper;
using CaterpillarControlService.API.Controllers;
using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Dtos.Caterpillar;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterpillarControlServices.Tests.ControllerTests
{
    public class CaterpillarControllerTests
    {
        private readonly ICaterpillarRepository _caterpillarRepository;
        private readonly IPlanetRepository _planetRepository;

        private readonly IMapper _mapper;
        public CaterpillarControllerTests()
        {
            _caterpillarRepository = A.Fake<ICaterpillarRepository>();
            _planetRepository = A.Fake<IPlanetRepository>();

            _mapper = A.Fake<IMapper>();

        }
        [Fact]
        public void CaterpillarController_GetCaterpillars_ReturnOK()
        {
            //Arrange
            var caterpillars = A.Fake<ICollection<CaterpillarToDisplayDto>>();

            var caterpillarList = A.Fake<List<CaterpillarToDisplayDto>>();

            A.CallTo(() => _mapper.Map<List<CaterpillarToDisplayDto>>(caterpillars)).Returns(caterpillarList);

            var controller = new CaterpillarController(_caterpillarRepository,_planetRepository,_mapper);
            //Act

            var result = controller.GetCaterpillars();

            //Assert

            result.Should().NotBeNull();

            result.Should().BeOfType(typeof(OkObjectResult));
        }
    
    }

}
