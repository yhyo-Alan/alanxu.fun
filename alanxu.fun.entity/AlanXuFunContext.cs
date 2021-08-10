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
            modelBuilder.Entity<Article>().HasData(new Article[]
            {
                new Article{
                    Id = 1,
                    Title = "文章标题-测试",
                    Comment = "文章内容-测试"
                },
                new Article{
                    Id = 2,
                    Title = "testTitle",
                    Comment = "testComment"
                }
            });

            modelBuilder.Entity<Comment>().HasData(new Comment[] {
                new Comment{
                    Id=1,
                    PatientId=0,
                    Comments="赞赞赞",
                    ArticleId=1
                },
                new Comment{
                    Id=2,
                    PatientId=0,
                    Comments="好好好",
                    ArticleId=1
                },
                new Comment{
                    Id=3,
                    PatientId=1,
                    Comments="你也赞",
                    ArticleId=1
                }
            });
        }
        #endregion
    }
}
