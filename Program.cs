using System;
using ElectronCgi.DotNet;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace Rackham
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new APIService();
            var crawler = new Crawler();
            var estateAgency = "MoenGarantiemakelaars";

            await crawler.Crawl(estateAgency);

            // TODO: Not write to the Error line but currently it would go to the Dufresne pipeline then
            // Start the API Service. Must be run last because it is not async.
            Console.Error.WriteLine($"Starting API Service..."); 
            APIService.Start();

            
        }
    }
}