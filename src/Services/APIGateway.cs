using Privateer.Rackham.Models;
using Privateer.Rackham.Repositories;
using System;

namespace Privateer.Rackham.Services
{

    public class APIGateway : IAPIGateway
    {
        // TODO: Find out why I can't change it to _webHost, there is ambiguity somewhere
        private readonly IWebHostService _myWebHost;

        public APIGateway(IWebHostService webHost) {
            _myWebHost = webHost ?? throw new ArgumentNullException(nameof(webHost));

            // Should my APIGateway hold these? Or does this belong to Startup.cs
            SpiderRepository spiderRepository = new SpiderRepository(new Spider[]{
                new Spider { Key = Guid.NewGuid().ToString(), Name = "Spider A" },
                new Spider { Key = Guid.NewGuid().ToString(), Name = "Spider B" }
            });
            SpiderService spiderService = new SpiderService(spiderRepository);

            _myWebHost.Connection.OnAsync("get-one-spider-status", async (string source) =>
            {
                Console.Error.WriteLine("Getting one spider status...");
                var oneSpiderStatus = await spiderService.ReadOneStatusAsync();
                return oneSpiderStatus;
            });

            _myWebHost.Connection.OnAsync("get-all-spiders", async () =>
            {
                Console.Error.WriteLine("Getting all spiders...");
                var allSpiders = await spiderService.ReadAllAsync();
                return allSpiders;
            });

            // Listen for incoming messages. Must be run last because it is not async.
            Console.Error.WriteLine("Listening to incoming API requests...");
            _myWebHost.Connection.Listen();   
        }    
    }
}