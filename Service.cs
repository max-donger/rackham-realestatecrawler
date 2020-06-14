using System;
using ElectronCgi.DotNet;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace Rackham
{
    class APIService
    {
        public static void Start()
        {
            var redditClient = new Crawler();
            var connection = new ConnectionBuilder()
                                    .WithLogging(minimumLogLevel: LogLevel.Trace, logFilePath: "rackham-trace.log")
                                    .Build();

            var selectedSubreddit = "";
            connection.On("select-subreddit", (string newSubreddit) =>
            {
                selectedSubreddit = newSubreddit;
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
                            await redditClient.Start(selectedSubreddit);
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
    }
}