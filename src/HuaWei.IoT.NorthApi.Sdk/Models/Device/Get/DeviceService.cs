namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Get
{
    /// <summary>
    /// 设备服务信息
    /// </summary>
    public class DeviceService
    {
        /// <summary>
        /// 设备的服务标识。
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// 设备的服务类型。
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// 设备的服务信息。
        /// </summary>
        public ServiceInfo ServiceInfo { get; set; }

        /// <summary>
        /// 属性值对。
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 事件发生的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// <para>若需要显示本地时区时间，您需要自己进行时间转换。</para>
        /// </summary>
        public string EventTime { get; set; }
    }
}
