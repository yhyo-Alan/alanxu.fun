using alanxu.fun.entity;
using alanxu.fun.entity.DbEntity;
using alanxu.fun.entity.Dto;
using alanxu.fun.idata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.data
{
    public class ArticleData : IArticleData
    {
        private readonly AlanXuFunContext _db;
        public ArticleData(AlanXuFunContext db)
        {
            _db = db;
        }
        public async Task<List<Article>> ArticleListAsync()
        {
            return await _db.Article.AsNoTracking().Where(a => a.State != -1).ToListAsync();
        }
    }
}
