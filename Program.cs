using ElectronCgi.DotNet;
using Microsoft.Extensions.Logging;

namespace Rackham
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webhost = new WebHost();
            var service = new newService(webhost);

            // Build the webhost so connections can be accepted
            webhost.BuildWebHost();
            
            // Get the connection status
            service.GetConnectionStatus(webhost.connection);

            // var service = new APIService();

            // var crawler = new Crawler();
            // var estateAgency = "MoenGarantiemakelaars";

            // await crawler.Crawl(estateAgency);

            // TODO: Not write to the Error line but currently it would go to the Dufresne pipeline then
            // Start the API Service. Must be run last because it is not async.
            // Console.Error.WriteLine($"Starting API Service..."); 
            // APIService.Start();    
        }
        public class WebHost : IWebHost
        {
            public Connection connection { get; set; }
            
            public void BuildWebHost() {
                Connection instance = new ConnectionBuilder()
                    .WithLogging(minimumLogLevel: LogLevel.Trace, logFilePath: "rackham-trace.log")
                    .Build();
            instance.Listen(); // should i go before or after the this?
            this.connection = instance;
            }
        }
    }
}
