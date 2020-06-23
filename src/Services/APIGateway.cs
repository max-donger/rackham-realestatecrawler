using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ElectronCgi.DotNet;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using Privateer.Rackham.Models;
using Privateer.Rackham.Services;
using Privateer.Rackham.Repositories;

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

            // TODO: Can I move this all elsewhere?
            // Get the connection status
            _myWebHost.Connection.OnAsync("connection-status", async (string source) =>
            {
                Console.WriteLine("Getting connection status");
                await GetConnectionStatus();
            });

            _myWebHost.Connection.OnAsync("get-all-spiders", async () =>
            {
                // TODO prevent Dufresne from reading this -> Console.WriteLine("Getting all spiders");
                var allSpiders = await spiderService.ReadAllAsync();
                return allSpiders;
            });

            // on receiving "start"
            CancellationTokenSource cancelationTokenSource = new CancellationTokenSource();
            _myWebHost.Connection.OnAsync("start", async () =>
            {
                Console.Error.WriteLine("started"); //this will show up in the node console
                await Task.Run(async () =>
                {
                    while (true)
                    {
                        if (cancelationTokenSource.Token.IsCancellationRequested)
                            return;
                        try
                        {
                            // await crawler.Crawl(selectedSubreddit); //get a new crawl (currently broken)
                            // var posts = await apiService.GetLatestCrawl(selectedSubreddit);
                            // connection.Send("show-posts", posts);
                            await Task.Delay(5000);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine($"Failed to get posts for (maybe it does not exist?)"); //this will show up in the node console
                            Console.Error.WriteLine(ex.Message);
                            return;                            
                        }
                    }
                }, cancelationTokenSource.Token);
            });

            // on receiving "stop"
            _myWebHost.Connection.On("stop", () =>
            {
                Console.Error.WriteLine("Stop");
                if (cancelationTokenSource != null)
                {
                    cancelationTokenSource.Cancel(); //this will cause the start request to complete
                }
            });

            // Listen for incoming messages. Must be run last because it is not async.
            // TODO prevent Dufresne from reading this -> Console.WriteLine("Listening...");
            _myWebHost.Connection.Listen();   
        }

        public async Task<int> GetConnectionStatus() {
            int output;
            // TODO: Remove randomness for testing and add actual check
            Random rand = new Random();
            if (rand.Next(0, 2) != 0)
            {
                output = 1;
            }
            else {
                output = 2;
            }
            Console.WriteLine("ConnectionStatus = " + output);
            return output;
        }

    
    }
}