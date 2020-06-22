using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Privateer.Rackham.Models;
using ElectronCgi.DotNet;

namespace Privateer.Rackham.Repositories
{
    public class SpiderRepository : ISpiderRepository
    {
        public Task<IEnumerable<Spider>> ReadAllAsync(Connection connection)
        {
            throw new NotImplementedException();
        }

        public Task<Spider> ReadOneAsync(Connection connection)
        {
            throw new NotImplementedException();
        }

        public Task<Spider> ToggleActiveAsync(Connection connection)
        {
            throw new NotImplementedException();
        }
    }
}