namespace HuaWei.IoT.NorthApi.Sdk
{
    /// <summary>
    /// 配置项
    /// </summary>
    public class NorthApiOptions
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 接口基础路径
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// 证书
        /// </summary>
        public NorthApiCert Cert { get; set; }

        /// <summary>
        /// 刷新令牌定时器
        /// </summary>
        public bool RefreshTokenTimer { get; set; } = true;
    }

    /// <summary>
    /// 证书
    /// </summary>
    public class NorthApiCert
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
