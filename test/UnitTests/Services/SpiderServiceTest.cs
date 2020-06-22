using System;
using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Privateer.Rackham.Repositories;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Services
{
    public class SpiderServiceTest
    {
        protected SpiderService ServiceUnderTest { get; }
        protected Mock<ISpiderRepository> SpiderRepositoryMock { get; }

        public SpiderServiceTest()
        {
            SpiderRepositoryMock = new Mock<ISpiderRepository>();
            ServiceUnderTest = new SpiderService(SpiderRepositoryMock.Object);
        }
        public class ReadAllAsync : SpiderServiceTest
        {
            [Fact]
            public async Task Should_return_all_spiders()
            {
                // Arrange
                var expectedSpiders = new ReadOnlyCollection<Spider>(new List<Spider>
                {
                    new Spider { Name = "Spider 1" },
                    new Spider { Name = "Spider 2" },
                    new Spider { Name = "Spider 3" }
                });
                SpiderRepositoryMock
                    .Setup(x => x.ReadAllAsync())
                    .ReturnsAsync(expectedSpiders);

                // Act
                var result = await ServiceUnderTest.ReadAllAsync();

                // Assert
                Assert.Same(expectedSpiders, result);
            }
        }
        public class ReadOneAsync : SpiderServiceTest
        {
            [Fact]
            public async Task Should_return_one_spider()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotImplementedException>(() => ServiceUnderTest.ReadOneAsync());
            }
        }
        public class ToggleActiveAsync : SpiderServiceTest
        {
            [Fact]
            public async Task Should_toggle_spider_active_status()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotImplementedException>(() => ServiceUnderTest.ToggleActiveAsync());
            }
        }
    }
}