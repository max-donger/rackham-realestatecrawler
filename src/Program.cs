using Privateer.Rackham.Services;
using System;

namespace Privateer.Rackham
{
    public class Program
    {
        // TODO prevent Dufresne from all Console.WriteLine in this project. Current workaround is Console.Error.WriteLine
        public static void Main(string[] args)
        {
            var webhostService = new WebHostService();

            // Build the WebHost so connections can be accepted  
            Console.Error.WriteLine("Building WebHost...");
            webhostService.BuildWebHost();
            
            // Start the API Gateway
            Console.Error.WriteLine("Starting API Gateway...");
            new APIGateway(webhostService);
        }
    }
}
