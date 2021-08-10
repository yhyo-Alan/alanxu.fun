using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.entity.DbEntity
{
    /// <summary>
    /// 文章评论
    /// </summary>
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 上级id，为0则表示没有上级
        /// </summary>
        public int PatientId { get; set; } = 0;

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 评论内容
        /// </summary>
        [MaxLength(300, ErrorMessage = "评论不能多余300个字符")]
        public string Comments { get; set; }

        public int ArticleId { get; set; }
    }
}
