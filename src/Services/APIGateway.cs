using Privateer.Rackham.Models;
using Privateer.Rackham.Repositories;
using Privateer.Rackham.Controllers;
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
                new Spider { Key = "67b0bf97-e9d4-4195-b372-d172b6777889", Name = "TwitterAPI Spider", Active = 1 },
                new Spider { Key = Guid.NewGuid().ToString(), Name = "FacebookAPI Spider", Active = 0 },
                new Spider { Key = Guid.NewGuid().ToString(), Name = "Website Spider", Active = 1 }
            });
            SpiderService spiderService = new SpiderService(spiderRepository);

            // SpiderController spiderController = new SpiderController(spiderService);

            _myWebHost.Connection.OnAsync("toggle-one-spider-active-state", async (string spiderKey) =>
            {
                // TODO: Add check if its turn on, so it only toggles if its enabled
                Console.Error.WriteLine("Toggle one spider active state...");
                var toggledActiveSpider = await spiderService.ToggleOneActiveAsync(spiderKey);
                return toggledActiveSpider;
            });

            _myWebHost.Connection.OnAsync("get-one-spider-health-state", async (string spiderKey) =>
            {
                Console.Error.WriteLine("Getting one spider health state...");
                var oneSpiderHealthState = await spiderService.ReadOneStatusAsync();
                return oneSpiderHealthState;
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