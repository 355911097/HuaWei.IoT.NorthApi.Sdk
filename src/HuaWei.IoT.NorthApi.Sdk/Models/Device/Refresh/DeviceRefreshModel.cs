namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Refresh
{
    /// <summary>
    /// 刷新设备密钥模型
    /// </summary>
    public class DeviceRefreshModel
    {
        /// <summary>
        /// 设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// <para>必选</para>
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 设备唯一标识码，通常使用MAC地址，Serial No或IMEI作为nodeId.若需要更新设备的nodeId，则填写此参数，否则不需要填写
        /// <para>可选</para>
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// 超时时间。在超时时间内可绑定设备，若超过timeout时间且未绑定设备，则会删除超时的开户信息。
        /// <para>取值范围：0～2147483647。若填写为“0”，则表示设备验证码不会失效（建议填写为“0”）。</para>
        /// <para>默认值：180（默认值可配置，具体配置值请咨询物联网平台运维人员。)</para>
        /// <para>单位：秒</para>
        /// <para>可选</para>
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 设备验证码，若在请求中指定verifyCode，则响应中返回请求中指定的verifyCode；若请求中不指定verifyCode，则由物联网平台自动生成。
        /// <para>对于集成了Agent Lite SDK的设备，必须与nodeId设置成相同值。</para>
        /// <para>可选</para>
        /// </summary>
        public string VerifyCode { get; set; }
    }
}
