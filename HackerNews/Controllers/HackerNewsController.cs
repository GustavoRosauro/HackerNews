using HackerNewsService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Controllers
{
    [Route("api/best20")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;
        public HackerNewsController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }
        [HttpGet]
        public async Task<ActionResult> ReturnBestStories()
        {
            var storiesContract = await  _hackerNewsService.ReturnTwentyStories();
            return Ok(storiesContract);
        }
    }
}
