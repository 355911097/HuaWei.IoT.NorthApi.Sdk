
namespace HuaWei.IoT.NorthApi.Sdk.Models.Service
{
    /// <summary>
    /// 设备的服务数据
    /// </summary>
    public class DeviceServiceDataModel
    {
        /// <summary>
        /// 服务ID。
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// 服务的类型。
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// 服务数据信息。
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 事件发生的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// <para>若需要显示本地时区时间，您需要自己进行时间转换。</para>
        /// </summary>
        public string EventTime { get; set; }
    }
}
