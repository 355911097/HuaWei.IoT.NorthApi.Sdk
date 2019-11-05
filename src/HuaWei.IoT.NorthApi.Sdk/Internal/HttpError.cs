namespace HuaWei.IoT.NorthApi.Sdk.Internal
{
    /// <summary>
    /// 请求错误信息
    /// </summary>
    public class HttpError
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public string Error_Code { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string Error_Desc { get; set; }
    }
}
