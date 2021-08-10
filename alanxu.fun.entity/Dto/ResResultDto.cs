using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alanxu.fun.entity.Dto
{
    public class ResResultDto
    {
        /// <summary>
        /// 数据状态
        /// </summary>
        public bool IsOk { get; set; } = true;

        /// <summary>
        /// 数据状态
        /// </summary>
        public string Msg { get; set; } = "success";

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { get; set; } = default;

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResResultDto ToSuccess(object data)
        {
            return new ResResultDto
            {
                Data = data
            };
        }

        public static ResResultDto ToFail(string msg)
        {
            return new ResResultDto
            {
                IsOk = false,
                Msg = msg,
                Data = null
            };
        }
    }
}
