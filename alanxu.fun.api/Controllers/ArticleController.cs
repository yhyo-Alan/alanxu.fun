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
    /// <summary>
    /// 文章
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleServer _server;
        public ArticleController(IArticleServer server)
        {
            _server = server;
        }

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResResultDto> ArticleListAsync()
        {
            return await _server.ArticleListAsync();
        }

        /// <summary>
        /// 文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResResultDto> ArticleContentAsync(int id)
        {
            return await _server.ArticleContentAsync(id);
        }
    }
}
