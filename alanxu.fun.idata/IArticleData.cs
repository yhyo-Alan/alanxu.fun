using alanxu.fun.entity.DbEntity;
using alanxu.fun.entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.idata
{
    public interface IArticleData
    {
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        Task<List<Article>> ArticleListAsync();
    }
}
