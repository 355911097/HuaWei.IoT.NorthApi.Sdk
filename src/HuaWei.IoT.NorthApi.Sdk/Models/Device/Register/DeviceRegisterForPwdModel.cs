namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Register
{
    /// <summary>
    /// 设备注册模型(密码方式)
    /// </summary>
    public class DeviceRegisterForPwdModel
    {
        /// <summary>
        /// 设备信息
        /// <para>可选</para>
        /// </summary>
        public DeviceRegisterInfoForPwd DeviceInfo { get; set; }

        /// <summary>
        /// 终端用户ID
        /// <para>在NB-IoT方案中，endUserId设置为设备的IMSI号</para>
        /// <para>可选</para>
        /// </summary>
        public string EndUserId { get; set; }

        /// <summary>
        /// 设备所属的组织信息
        /// <para>可选</para>
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// 设备所在的区域信息
        /// <para>可选</para>
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 设备是否使用MQTT协议接入，注册MQTT协议接入设备时需要设置为true。
        /// <para>可选</para>
        /// </summary>
        public bool MqttConnect { get; set; }

        /// <summary>
        /// 设备所属的产品ID，用于关联设备所属的产品模型
        /// <para>与manufacturerId、manufacturerName、deviceType、model和protocolType系列参数二选一。</para>
        /// <para>可选</para>
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 设备密码，格式要求为20位16进制数。
        /// <para>若在请求中指定secret，则响应中返回请求中指定的secret；若请求中不指定secret，则由物联网平台自动生成。</para>
        /// <para>可选</para>
        /// </summary>
        public string Secret { get; set; }
    }
}
