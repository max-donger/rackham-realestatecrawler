using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronCgi.DotNet;

namespace Privateer.Rackham
{
    public interface IWebHostService
    {
        public Connection Connection {get; set;}
        public void BuildWebHost();
    }
}