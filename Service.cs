using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ElectronCgi.DotNet;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace Rackham
{
        public class RealEstateInfoX
    {
        public string Title { get; set; }
        public string UpvoteCount { get; set; }
        public string Url { get; set; }
    }

    public class APIService
    {
        /*
        public async Task GetConnectionStatus(webhost) {
            webhost.OnAsync("connection-status", async (string source) =>
            {
                var status = await crawler.checkStatus(source);
                return status;
            });
        }
        */
        public static void Start()
        {
            var crawler = new Crawler();
            var apiService = new APIService(); // This is bad, I should probably move the GetLatestCrawl to another file
            var connection = new ConnectionBuilder()
                                    .WithLogging(minimumLogLevel: LogLevel.Trace, logFilePath: "rackham-trace.log")
                                    .Build();

            var selectedSubreddit = "";
            connection.On("select-subreddit", (string newSubreddit) =>
            {
                selectedSubreddit = newSubreddit;
            });

            connection.OnAsync("connection-status", async (string source) =>
            {
                var status = await crawler.checkStatus(source);
                return status;
            });

            CancellationTokenSource cancelationTokenSource = new CancellationTokenSource();
            connection.OnAsync("start", async () =>
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
                            Console.Error.WriteLine($"Failed to get posts for {selectedSubreddit} (maybe it does not exist?)"); //this will show up in the node console
                            Console.Error.WriteLine(ex.Message);
                            return;                            
                        }
                    }
                }, cancelationTokenSource.Token);
            });

            connection.On("stop", () =>
            {
                Console.Error.WriteLine("Stop");
                if (cancelationTokenSource != null)
                {
                    cancelationTokenSource.Cancel(); //this will cause the start request to complete
                }
            });

            connection.Listen();            
        }
        /*
        private async Task<IEnumerable<RealEstateInfoX>> GetLatestCrawl(string source)
        {
            var jsonLocal = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(@"G:/Electron/source/repos/rackham-realestatecrawler/test/funda.json"));

            return ((IEnumerable<dynamic>)jsonLocal.realestate).Select(post => new RealEstateInfoX
            {
                Title = post.streetname,
                UpvoteCount = post.number,
                Url = post.zipcode
            });
        }
        */
    }
}