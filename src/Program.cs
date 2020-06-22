using ElectronCgi.DotNet;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;
using Privateer.Rackham.Services;
using Privateer.Rackham.Repositories;
using Privateer.Rackham.Models;

namespace Privateer.Rackham
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webhostService = new WebHostService();

            // Build the webhost so connections can be accepted
            Console.WriteLine("Building webhost");
            webhostService.BuildWebHost();
            
            // SpiderService spiderService = new SpiderService();
            // spiderService.Crawl(estateAgency);

            // Start listening...
            new APIGateway(webhostService);
        }
    }
}
