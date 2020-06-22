using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Privateer.Rackham.Services;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Controllers
{
    public class SpiderControllerTest
    {
        protected SpiderController ControllerUnderTest { get; }
        protected Mock<ISpiderService> SpiderServiceMock { get; }

        public SpiderControllerTest()
        {
            SpiderServiceMock = new Mock<ISpiderService>();
            ControllerUnderTest = new SpiderController(SpiderServiceMock.Object);
        }
        public class ReadAllAsync : SpiderControllerTest
        {
            [Fact]
            public async void Should_return_OkObjectResult_with_spiders()
            {
                // Arrange
                var expectedSpiders = new Spider[]
                {
                    new Spider { Name = "Test spider 1" },
                    new Spider { Name = "Test spider 2" },
                    new Spider { Name = "Test spider 3" }
                };
                SpiderServiceMock
                    .Setup(x => x.ReadAllAsync())
                    .ReturnsAsync(expectedSpiders);

                // Act
                var result = await ControllerUnderTest.ReadAllAsync();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                // ControllerUnderTest is not generating the same spiders as the 3 above
                Assert.Same(expectedSpiders, result);
            }
        }
        public class ReadOneAsync : SpiderControllerTest
        {
            [Fact]
            public async Task Should_return_one_spider()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotImplementedException>(() => ControllerUnderTest.ReadOneAsync());
            }
        }
        public class ToggleActiveAsync : SpiderControllerTest
        {
            [Fact]
            public async Task Should_toggle_spider_active_status()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotImplementedException>(() => ControllerUnderTest.ToggleActiveAsync());
            }
        }
    }
}