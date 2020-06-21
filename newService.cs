using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ElectronCgi.DotNet;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using Rackham.Models;

namespace Rackham
{

    public class newService : IService
    {
        // TODO: Find out why I can't change it to _webHost, there is ambiguity somewhere
        private readonly IWebHost _myWebHost;

        public newService(IWebHost webHost) {
            _myWebHost = webHost ?? throw new ArgumentNullException(nameof(webHost));
        }

        public async Task<bool> GetConnectionStatus(Connection connection) {

            // throw new NotImplementedException();
            /*await connection.OnAsync("connection-status", async (string source) =>
            {
                var status = await crawler.checkStatus(source);
                return status;
            });*/

            // Placeholder
            return true;
        }
    }
}