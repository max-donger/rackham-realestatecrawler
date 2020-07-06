using System.Collections.Generic;
using System.Threading.Tasks;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Controllers
{
    public interface ISpiderController
    {   
        Task<IEnumerable<Spider>> ReadAllAsync();
        Task<Spider> ReadOneAsync();
        Task<int> ToggleOneActiveAsync(string spiderKey);
    }
}