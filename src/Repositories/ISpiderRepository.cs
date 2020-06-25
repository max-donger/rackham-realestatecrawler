using System.Collections.Generic;
using System.Threading.Tasks;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Repositories
{
    public interface ISpiderRepository
    {   
        Task<IEnumerable<Spider>> ReadAllAsync();
        Task<Spider> ReadOneAsync();
        Task<Spider> ToggleActiveAsync();
        
    }
}