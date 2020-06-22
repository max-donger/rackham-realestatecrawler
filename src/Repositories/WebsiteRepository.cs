using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Privateer.Rackham.Models;
using ElectronCgi.DotNet;

namespace Privateer.Rackham.Repositories
{
    public class WebsiteRepository : IWebsiteRepository
    {
        public Task<IEnumerable<Website>> ReadAllAsync(Connection connection)
        {
            throw new NotImplementedException();
        }

        public Task<Website> ReadOneAsync(Connection connection)
        {
            throw new NotImplementedException();
        }

        public Task<Website> CreateAsync(Connection connection)
        {
            throw new NotImplementedException();
        }

        public Task<Website> UpdateAsync(Connection connection)
        {
            throw new NotImplementedException();
        }

        public Task<Website> DeleteAsync(Connection connection)
        {
            throw new NotImplementedException();
        }
    }
}