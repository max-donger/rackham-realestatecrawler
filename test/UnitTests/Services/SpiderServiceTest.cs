using System;
using Xunit;
using System.Threading.Tasks;

namespace Privateer.Rackham.Services
{
    public class SpiderServiceTest
    {
        protected SpiderService ServiceUnderTest { get; }

        public SpiderServiceTest()
        {
            ServiceUnderTest = new SpiderService();
        }
        public class ReadAllAsync : SpiderServiceTest
        {
            [Fact]
            public async Task Should_return_all_spiders()
            {
                // Arrange, Act, Assert
                var exception = await Assert.ThrowsAsync<NotImplementedException>(() => ServiceUnderTest.ReadAllAsync());
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