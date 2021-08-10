using alanxu.fun.entity.DbEntity;
using alanxu.fun.entity.Dto;
using alanxu.fun.idata;
using alanxu.fun.iserver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.server
{
    public class ArticleServer : IArticleServer
    {
        private readonly IArticleData _db;
        public ArticleServer(IArticleData db)
        {
            _db = db;
        }


        /// <summary>
        /// 查询文章列表
        /// </summary>
        /// <returns></returns>
        public async Task<ResResultDto> ArticleListAsync()
        {
            return ResResultDto.ToSuccess(await _db.ArticleListAsync());
        }

        /// <summary>
        /// 通过文章id获取文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResResultDto> ArticleContentAsync(int id)
        {
            return ResResultDto.ToSuccess(await _db.ArticleContentAsync(id));
        }
    }
}
