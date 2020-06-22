using System;
using System.Collections.Generic;
using System.Linq;
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
        public Task ToggleActiveAsync()
        {
            throw new NotImplementedException();
        }
    }
}