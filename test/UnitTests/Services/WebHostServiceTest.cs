using Xunit;

namespace Privateer.Rackham.Services
{
    public class WebHostServiceTest
    {
        protected WebHostService ServiceUnderTest { get; }

        public WebHostServiceTest()
        {
            ServiceUnderTest = new WebHostService();
        }

        public class GetConnectionStatus : WebHostServiceTest
        {
            [Fact]
            public void Should_return_connection()
            {
                // Arrange and Act
                ServiceUnderTest.BuildWebHost();
                var conn = ServiceUnderTest.Connection;

                // Assert
                Assert.NotNull(conn);
            }
        }
    }
}