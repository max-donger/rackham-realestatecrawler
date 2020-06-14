using Microsoft.Extensions.Logging;
using ElectronCgi.DotNet;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new ConnectionBuilder()
                .WithLogging(minimumLogLevel: LogLevel.Trace, logFilePath: "rackham-trace.log")
                .Build();
            
            // expects a request named "greeting" with a string argument and returns a string
            connection.On<string, string>("greeting", name => "Hello " + name);
            connection.Listen();    
        }
    }
}
