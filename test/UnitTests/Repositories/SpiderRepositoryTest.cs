using Xunit;
using System.Threading.Tasks;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Repositories
{
    public class SpiderRepositoryTest
    {
        protected SpiderRepository RepositoryUnderTest { get; }
        protected Spider[] spiders { get; }

        public SpiderRepositoryTest()
        {
            spiders = new Spider[]
            {
                new Spider { Name = "Spider 1" },
                new Spider { Name = "Spider 2" },
                new Spider { Name = "Spider 3" }
            };
            RepositoryUnderTest = new SpiderRepository(spiders);
        }
        public class ReadAllAsync : SpiderRepositoryTest
        {
            [Fact]
            public async Task Should_return_all_spiders()
            {
                // Act
                var result = await RepositoryUnderTest.ReadAllAsync();

                // Assert
                Assert.Collection(result,
                    clan => Assert.Same(spiders[0], clan),
                    clan => Assert.Same(spiders[1], clan),
                    clan => Assert.Same(spiders[2], clan)
                );
            }
        }
    }
}