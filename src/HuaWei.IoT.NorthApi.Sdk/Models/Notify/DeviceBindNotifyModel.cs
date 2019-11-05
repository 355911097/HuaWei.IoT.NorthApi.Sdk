using HuaWei.IoT.NorthApi.Sdk.Enums;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Get;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备绑定通知模型
    /// </summary>
    public class DeviceBindNotifyModel : BaseNotifyModel
    {
        /// <summary>
        /// 绑定结果
        /// </summary>
        public BindResult ResultCode { get; set; }

        /// <summary>
        /// 设备信息
        /// </summary>
        public DeviceInfo DeviceInfo { get; set; }
    }
}
