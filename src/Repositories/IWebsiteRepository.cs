using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronCgi.DotNet;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Repositories
{
    public interface IWebsiteRepository
    {   
        Task<IEnumerable<Website>> ReadAllAsync(Connection connection);
        Task<Website> ReadOneAsync(Connection connection);
        Task<Website> CreateAsync(Connection connection);
        Task<Website> UpdateAsync(Connection connection);
        Task<Website> DeleteAsync(Connection connection);
    }
}