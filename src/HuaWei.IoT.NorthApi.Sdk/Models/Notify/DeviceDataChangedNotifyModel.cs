using HuaWei.IoT.NorthApi.Sdk.Models.Service;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备数据变化通知模型
    /// </summary>
    public class DeviceDataChangedNotifyModel : BaseNotifyModel
    {
        /// <summary>
        /// 消息的序列号，唯一标识该消息。
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 网关ID
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 设备的服务数据
        /// </summary>
        public DeviceServiceDataModel Service { get; set; }
    }
}
