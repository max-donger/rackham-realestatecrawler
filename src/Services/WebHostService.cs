using Microsoft.Extensions.Logging;
using ElectronCgi.DotNet;

namespace Privateer.Rackham.Services
{
    public class WebHostService : IWebHostService
    {
        public Connection Connection { get; set; }
            
        public void BuildWebHost() {
            Connection instance = new ConnectionBuilder()
                .WithLogging(minimumLogLevel: LogLevel.Trace, logFilePath: "rackham-trace.log")
                .Build();
            
            this.Connection = instance;
        }
    }
}