namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Refresh
{
    /// <summary>
    /// 刷新设备密钥结果
    /// </summary>
    public class DeviceRefreshResult
    {
        /// <summary>
        /// 设备验证码，设备可以通过验证码完成物联网平台的接入认证。
        /// <para>若在请求中指定verifyCode，则响应中返回请求中指定的verifyCode；若请求中不指定verifyCode，则由物联网平台自动生成。</para>
        /// </summary>
        public string VerifyCode { get; set; }

        /// <summary>
        /// 验证码有效时间，单位秒，设备需要在有效时间内接入物联网平台。
        /// </summary>
        public int Timeout { get; set; }
    }
}
