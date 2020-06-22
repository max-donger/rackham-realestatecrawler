using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronCgi.DotNet;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Repositories
{
    public interface IEstateAgencyService
    {
        Task<IEnumerable<EstateAgency>> ReadAllAsync(Connection connection);
        Task<EstateAgency> ReadOneAsync(Connection connection);
        Task<EstateAgency> CreateAsync(Connection connection);
        Task<EstateAgency> UpdateAsync(Connection connection);
        Task<EstateAgency> DeleteAsync(Connection connection);
    }
}