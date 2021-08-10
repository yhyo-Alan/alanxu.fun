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
        public async Task<ResResultDto> ArticleListAsync()
        {
            return ResResultDto.ToSuccess(await _db.ArticleListAsync());
        }
    }
}
