namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.DataHistory
{
    /// <summary>
    /// 设备历史数据查询模型
    /// </summary>
    public class DeviceDataHistoryQueryModel : NorthApiQueryPaging
    {
        /// <summary>
        /// 设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// <para>必选</para>
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 网关ID，用于标识一个网关设备。
        /// <para>当设备是直连设备时，gatewayId与设备的deviceId一致。</para>
        /// <para>当设备是非直连设备时，gatewayId为设备所关联的直连设备（即网关）的deviceId。</para>
        /// <para>必选</para>
        /// </summary>
        public string GatewayId { get; set; }
    }
}
