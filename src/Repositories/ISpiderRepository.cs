using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronCgi.DotNet;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Repositories
{
    public interface ISpiderRepository
    {   
        Task<IEnumerable<Spider>> ReadAllAsync(Connection connection);
        Task<Spider> ReadOneAsync(Connection connection);
        Task<Spider> ToggleActiveAsync(Connection connection);
        
    }
}