namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.DataHistory
{
    /// <summary>
    /// 设备历史数据信息
    /// </summary>
    public class DeviceDataHistoryModel
    {
        /// <summary>
        /// 设备的服务标识。
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// 设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 网关ID，用于标识一个网关设备。
        /// <para>当设备是直连设备时，gatewayId与设备的deviceId一致。</para>
        /// <para>当设备是非直连设备时，gatewayId为设备所关联的直连设备（即网关）的deviceId。</para>
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 设备所属的应用ID。
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 设备上报的数据。
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 上报数据的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// <para>若需要显示本地时区时间，您需要自己进行时间转换。</para>
        /// </summary>
        public string Timestamp { get; set; }
    }
}
