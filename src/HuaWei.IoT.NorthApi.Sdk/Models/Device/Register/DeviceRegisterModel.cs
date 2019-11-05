namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Register
{
    /// <summary>
    /// 设备注册模型(验证码方式)
    /// </summary>
    public class DeviceRegisterModel
    {
        /// <summary>
        /// 设备信息
        /// <para>可选</para>
        /// </summary>
        public DeviceRegisterInfo DeviceInfo { get; set; }

        /// <summary>
        /// 终端用户ID
        /// <para>在NB-IoT方案中，endUserId设置为设备的IMSI号</para>
        /// <para>可选</para>
        /// </summary>
        public string EndUserId { get; set; }

        /// <summary>
        /// B-IoT终端的IMSI
        /// <para>可选</para>
        /// </summary>
        public string Imsi { get; set; }

        /// <summary>
        /// 指定设备是否为安全设备，默认值为false
        /// <para>在NB-IoT场景下，注册的设备为加密设备时，isSecure要设置为true。</para>
        /// <para>可选</para>
        /// </summary>
        public bool IsSecure { get; set; }

        /// <summary>
        /// 设备唯一标识码，必须与设备上报的设备标识一致。通常使用IMEI、MAC地址或Serial No作为nodeId。
        /// <para>使用IMEI作为nodeId时，根据不同厂家的芯片有不同填写要求。</para>
        /// <para>高通芯片设备的唯一标识为urn:imei:xxxx，xxxx为IMEI号</para>
        /// <para>海思芯片设备的唯一标识为IMEI号</para>
        /// <para>其他厂家芯片的设备唯一标识请联系模组厂家确认</para>
        /// <para>必选</para>
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// 请求中指定psk，则平台使用指定的psk；请求中不指定psk，则由平台生成psk。取值范围是a-f、A-F、0-9组成的字符串。
        /// <para>可选</para>
        /// </summary>
        public string Psk { get; set; }

        /// <summary>
        /// 设备验证码的超时时间，单位：秒。若设备在有效时间内未接入物联网平台并激活，则平台会删除该设备的注册信息。
        /// <para>取值范围：0～2147483647。若填写为“0”，则表示设备验证码不会失效（建议填写为“0”）。</para>
        /// <para>默认值：180（默认值可配置，具体配置值请咨询物联网平台运维人员)</para>
        /// <para>可选</para>
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 设备验证码，若在请求中指定verifyCode，则响应中返回请求中指定的verifyCode；若请求中不指定verifyCode，则由物联网平台自动生成。
        /// <para>在注册集成了Agent Lite SDK的设备时需要设置verifyCode，且必须与nodeId设置成相同值。</para>
        /// <para>可选</para>
        /// </summary>
        public string VerifyCode { get; set; }

        /// <summary>
        /// 设备所属的产品ID，用于关联设备所属的产品模型。与manufacturerId、manufacturerName、deviceType、model和protocolType系列参数二选一。
        /// <para>可选</para>
        /// </summary>
        public string ProductId { get; set; }
    }
}
