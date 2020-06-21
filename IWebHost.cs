using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronCgi.DotNet;

namespace Rackham
{
    public interface IWebHost
    {
        public Connection connection {get; set;}
        public void BuildWebHost();
    }
}