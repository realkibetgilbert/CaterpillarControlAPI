using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterpillarControlService.UnitTests.ControllerTests
{
    public  class AuthControllerTests
    {
        private Mock<ICaterpillarRepository> _mockCaterpillarRepository;

        private Caterpillar _caterpillarController;

        [SetUp]
        public void Setup()
        {
            _mockProductService = new Mock<IProductService>();
            _productController = new ProductController(_mockProductService.Object);
        }
    }
}
