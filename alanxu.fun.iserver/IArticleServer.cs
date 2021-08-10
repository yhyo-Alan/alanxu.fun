using alanxu.fun.entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.iserver
{
    public interface IArticleServer
    {
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        Task<ResResultDto> ArticleListAsync();

        Task<ResResultDto> ArticleContentAsync(int id);
    }
}
