namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Register
{
    /// <summary>
    /// 设备注册结果(密码方式)
    /// </summary>
    public class DeviceRegisterForPwdResult
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
        /// 设备密码，设备可以通过验证码完成物联网平台的接入认证
        /// <para>若在请求中指定secret，则响应中返回请求中指定的secret；若请求中不指定secret，则由物联网平台自动生成。</para>
        /// </summary>
        public string Secret { get; set; }
    }
}
