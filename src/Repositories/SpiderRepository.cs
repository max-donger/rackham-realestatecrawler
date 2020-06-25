using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Repositories
{
    public class SpiderRepository : ISpiderRepository
    {
        private readonly List<Spider> _spiders;
        public SpiderRepository(IEnumerable<Spider> spiders) 
        {
            if (spiders == null) { throw new ArgumentNullException(nameof(spiders)); }
            _spiders = new List<Spider>(spiders);
        }
        public Task<IEnumerable<Spider>> ReadAllAsync()
        {
            return Task.FromResult(_spiders.AsEnumerable());
        }

        public Task<Spider> ReadOneAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Spider> ToggleActiveAsync()
        {
            throw new NotImplementedException();
        }
    }
}