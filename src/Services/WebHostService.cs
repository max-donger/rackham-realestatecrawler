using Privateer.Rackham.Controllers;
using Microsoft.Extensions.Logging;
using ElectronCgi.DotNet;
using System;

namespace Privateer.Rackham.Services
{
    public class WebHostService : IWebHostService
    {
        private ISpiderController _spiderController;
        public Connection Connection { get; set; }

        public WebHostService() 
        {
            // _spiderController = spiderController ?? throw new ArgumentNullException(nameof(spiderController));

            // TODO: Add fetch if a spider is enabled or disabled here
            // TODO: Add all estateAgencies here
            // TODO: Add a foreach if they are enabled, to start crawling
        }
            
        public void BuildWebHost() {
            Connection instance = new ConnectionBuilder()
                .WithLogging(minimumLogLevel: LogLevel.Trace, logFilePath: "rackham-trace.log")
                .Build();
            
            this.Connection = instance;
        }

        public void StartSpiderCrawl() {
            // _spiderController.ToggleOneCrawlAsync();
            
        }
    }
}