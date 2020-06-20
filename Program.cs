﻿using System;
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
            var crawlSource = "TibiaMMO";

            await crawler.Crawl(crawlSource);

            // Start the API Service. Must be run last because it is not async.
            APIService.Start();
        }
    }
}