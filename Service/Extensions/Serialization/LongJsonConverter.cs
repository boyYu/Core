using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Service.Utility.Extensions.Serialization
{
    /// <summary>
    /// Json 序列化 long 类型 转 string  以解决JS 获取long 类型失去精度问题
    /// 实现这三个抽象方法CanConvert()、ReadJson()、WriteJson()
    /// </summary>
    public class LongJsonConverter : JsonConverter
    {
        /// <summary>
        /// 判断是否需要自定义序列化或者反序列化的
        /// </summary>
        /// <param name="objectType">参数objectType对应着特性JsonConverter所标记类的对应Type类型</param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(System.Int64).Equals(objectType);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType">对象类型</param>
        /// <param name="existingValue">正在读取对象的现有值</param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken jt = JValue.ReadFrom(reader);
            return jt.Value<long?>();
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="writer">要写入的Newtonsoft.Json.JsonWriter</param>
        /// <param name="value">值</param>
        /// <param name="serializer">调用序列化程序</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
