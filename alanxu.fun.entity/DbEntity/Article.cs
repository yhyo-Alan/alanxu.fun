using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.entity.DbEntity
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        [MaxLength(32, ErrorMessage = "标题不能超过32个字符")]
        public string Title { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        [MaxLength(10000, ErrorMessage = "文章内容不能超过10000个字符")]
        public string Comment { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime ModifyTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 分享次数
        /// </summary>
        public int ShareCount { get; set; } = 0;

        /// <summary>
        /// 被点赞次数
        /// </summary>
        public int LikeCount { get; set; } = 0;

        /// <summary>
        /// 被踩次数
        /// </summary>
        public int DisLikeCount { get; set; } = 0;

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ReadCount { get; set; } = 0;

        /// <summary>
        /// 状态：0草稿 1正常 -1删除
        /// </summary>
        public int State { get; set; } = 0;

        /// <summary>
        /// 是否轮播：0不是 1是
        /// </summary>
        public int Swipe { get; set; } = 0;

        /// <summary>
        /// 是否推荐阅读：0不推荐  1推荐
        /// </summary>
        public int Recommend { get; set; } = 0;

        public List<Comment> Comments { get; set; }
    }
}
