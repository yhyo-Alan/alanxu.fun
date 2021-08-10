using alanxu.fun.entity.Dto;
using alanxu.fun.iserver;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alanxu.fun.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleServer _server;
        public ArticleController(IArticleServer server)
        {
            _server = server;
        }

        [HttpGet]
        public async Task<ResResultDto> ArticleListAsync()
        {
            return await _server.ArticleListAsync();
        }
    }
}
