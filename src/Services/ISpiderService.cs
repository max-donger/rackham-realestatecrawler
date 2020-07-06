using System.Collections.Generic;
using System.Threading.Tasks;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Services
{
    public interface ISpiderService
    {   
        // Read or toggle Spider
        Task<IEnumerable<Spider>> ReadAllAsync();
        Task<Spider> ReadOneAsync();
        Task<int> ToggleOneActiveAsync(string spiderKey);
        // TODO: Add ReadAllStatusAsync
        Task<int> ReadOneStatusAsync();
    }
}