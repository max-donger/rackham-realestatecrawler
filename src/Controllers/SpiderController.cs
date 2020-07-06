using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Privateer.Rackham.Services;
using Privateer.Rackham.Models;

namespace Privateer.Rackham.Controllers
{
    [Route("v1/[controller]")]
    public class SpiderController : Controller
    {
        private readonly ISpiderService _spiderService;
        public SpiderController(ISpiderService spiderService)
        {
            _spiderService = spiderService ?? throw new ArgumentNullException(nameof(spiderService));
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Spider>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allSpiders = await _spiderService.ReadAllAsync();
            return Ok(allSpiders);
        }
        public Task ReadOneAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> ToggleOneActiveAsync()
        {
            string spiderKey = "67b0bf97-e9d4-4195-b372-d172b6777889";
            var oneSpiderActive = await _spiderService.ToggleOneActiveAsync(spiderKey);
            return Ok(oneSpiderActive);
        }

        // TODO: Add to ISpiderController?
        /*[HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Spider>), 200)]
        public async Task<Spider> ToggleOneCrawlAsync(Website website)
        {      
            try {
                var oneCrawl = await _spiderService.ToggleOneCrawlAsync(website);
                // await Selenium(estateAgency);
            }
            catch {
                // throw new System.ArgumentException("Could not find estate agency.", estateAgency.Name);
            }
            return Ok(oneCrawl);
        } */
    }
}