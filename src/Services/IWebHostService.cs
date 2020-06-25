using ElectronCgi.DotNet;

namespace Privateer.Rackham
{
    public interface IWebHostService
    {
        public Connection Connection {get; set;}
        public void BuildWebHost();
    }
}