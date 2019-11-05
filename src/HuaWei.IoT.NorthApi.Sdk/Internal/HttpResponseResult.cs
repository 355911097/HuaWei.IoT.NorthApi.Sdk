using System.Net;

namespace HuaWei.IoT.NorthApi.Sdk.Internal
{
    /// <summary>
    /// 请求响应结果
    /// </summary>
    internal class HttpResponseResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 响应内容
        /// </summary>
        public string Content { get; set; }
    }
}
