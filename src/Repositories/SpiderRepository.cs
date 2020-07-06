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

        public async Task<Spider> ReadOneAsync()
        {
            var spider = await Task.FromResult(_spiders.FirstOrDefault());
            return spider;
            // throw new System.ArgumentException("Could not find estate agency.", estateAgency.Name);
        }

        public async Task<int> ToggleOneActiveAsync(string spiderKey)
        {
            int spiderActiveState = -999;

            var activeSpider = from spider in _spiders
                                where spider.Key == spiderKey
                                select spider;
            
            // This should be a count and throw an error if you have 0 or 2 results
            foreach (Spider spider in _spiders)
            {
                // Toggle the active state
                if (spider.Active == 0) {
                    spider.Active = 1;
                }
                else if (spider.Active == 1) {
                    spider.Active = 0;
                }
                else {
                    spider.Active = -888;
                }

                // Get the updated active state
                spiderActiveState = spider.Active;
            }

            return spiderActiveState;
        }
    }
}