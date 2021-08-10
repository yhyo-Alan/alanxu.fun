using alanxu.fun.entity.DbEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.entity
{
    public class AlanXuFunContext : DbContext
    {
        #region ctor
        public AlanXuFunContext()
        {

        }

        public AlanXuFunContext(DbContextOptions<AlanXuFunContext> options) : base(options)
        {

        }
        #endregion

        #region 实体集
        public DbSet<Article> Article { get; set; }
        //因为Article导航属性的原因，会自动映射Comment
        //public DbSet<Comment> Comment { get; set; }
        #endregion

        #region 方法重写
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(new Article()
            {
                Id = 1,
                Title = "文章标题-测试",
                Comment = "文章内容-测试"
            });
        }
        #endregion
    }
}
