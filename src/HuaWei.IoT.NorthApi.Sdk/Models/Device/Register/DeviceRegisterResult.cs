namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Register
{
    /// <summary>
    /// 设备注册结果(验证码方式)
    /// </summary>
    public class DeviceRegisterResult
    {
        /// <summary>
        /// 设备ID，用于唯一标识一个设备
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 随机psk参数，若请求中携带了psk，则使用请求中的psk，否则由平台生成随机psk参数。
        /// </summary>
        public string Psk { get; set; }

        /// <summary>
        /// 验证码有效时间，单位秒，设备需要在有效时间内接入物联网平台。
        /// </summary>
        public string Timeout { get; set; }

        /// <summary>
        /// 设备验证码，集成了Agent Lite SDK的设备需要使用验证码完成物联网平台的接入认证。
        /// <para>若在请求中指定verifyCode，则响应中返回请求中指定的verifyCode；若请求中不指定verifyCode，则由物联网平台自动生成。</para>
        /// </summary>
        public string VerifyCode { get; set; }
    }
}
