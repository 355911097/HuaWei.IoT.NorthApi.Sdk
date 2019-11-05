using System.Net;
using HuaWei.IoT.NorthApi.Sdk.Internal;

namespace HuaWei.IoT.NorthApi.Sdk.Models
{
    /// <summary>
    /// 返回模型
    /// </summary>
    public class NorthApiResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 说明信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 请求响应码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 请求错误信息
        /// </summary>
        public HttpError Error { get; set; }
    }

    /// <summary>
    /// 返回模型
    /// </summary>
    public class NorthApiResult<T> : NorthApiResult
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }
}
