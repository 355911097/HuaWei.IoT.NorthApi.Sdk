namespace HuaWei.IoT.NorthApi.Sdk
{
    /// <summary>
    /// 令牌信息
    /// </summary>
    public class NorthApiToken
    {
        /// <summary>
        /// 申请权限范围，即accessToken所能访问物联网平台资源的范围，参数值固定为default。
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// accessToken的类型，参数值固定为Bearer 。
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// accessToken的有效时间，参数值固定为3600秒。
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 鉴权参数，访问物联网平台API接口的凭证。
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 鉴权参数，有效时间为24小时，用于“刷新Token”接口。当accessToken即将过期时，可通过“刷新Token”接口来获取新的accessToken。
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
