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

        /// <summary>
        /// 查询文章列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Article>> ArticleListAsync()
        {
            return await _db.Article.AsNoTracking().Where(a => a.State != -1).Select(a => new Article
            {
                Id = a.Id,
                Title = a.Title,
                ModifyTime = a.ModifyTime
            }).OrderBy(a => a.CreateTime).ToListAsync();
        }

        /// <summary>
        /// 通过文章id获取文章内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Article>> ArticleContentAsync(int id)
        {
            return await _db.Article.AsNoTracking().Include(a => a.Comments).Where(a => a.Id.Equals(id)).ToListAsync();
        }
    }
}
