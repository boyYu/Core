using System;
using Newtonsoft.Json;
using Service.Utility.Extensions.Serialization;

namespace Model.DAO
{
    /// <summary>
    /// 基类
    /// </summary>
    public class Base
    {
        /// <summary>
        /// 主键
        /// </summary>
        [JsonConverter(typeof(LongJsonConverter))]
        public long ID { get; set; }

        /// <summary>
        /// 添加人ID
        /// </summary>
        [JsonConverter(typeof(LongJsonConverter))]
        public long? AddUser { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 最后更新人ID
        /// </summary>
		[JsonConverter(typeof(LongJsonConverter))]
        public long? UpdateUser { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 删除标志 true-1:未删除  false-0:已删除
        /// </summary>
        public bool Mark { get; set; }

        /// <summary>
        /// 有效/启用标志 true-1:有效  false:无效
        /// </summary>
        public bool? EnableMark { get; set; }
    }
}
