using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronCgi.DotNet;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Services
{
    public interface ISpiderService
    {   
        // Read or toggle Spider
        Task<IEnumerable<Spider>> ReadAllAsync();
        Task<Spider> ReadOneAsync();
        Task<Spider> ToggleActiveAsync();
        // Crawl
        Task Crawl(EstateAgency estateAgency);
    }
}