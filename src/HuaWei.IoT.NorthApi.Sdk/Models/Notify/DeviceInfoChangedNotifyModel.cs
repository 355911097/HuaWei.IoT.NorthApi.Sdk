using HuaWei.IoT.NorthApi.Sdk.Models.Device.Get;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备信息变化通知模型
    /// </summary>
    public class DeviceInfoChangedNotifyModel : BaseNotifyModel
    {
        /// <summary>
        /// 网关ID
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 设备信息
        /// </summary>
        public DeviceInfo DeviceInfo { get; set; }
    }
}
