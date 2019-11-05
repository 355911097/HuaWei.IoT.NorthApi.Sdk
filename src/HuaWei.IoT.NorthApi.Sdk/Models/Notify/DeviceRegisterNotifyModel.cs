using HuaWei.IoT.NorthApi.Sdk.Enums;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Get;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备注册通知模型
    /// </summary>
    public class DeviceRegisterNotifyModel : BaseNotifyModel
    {
        /// <summary>
        /// 网关ID，用于标识一个网关设备
        /// <para>当设备是直连设备时，gatewayId与设备的deviceId一致。</para>
        /// <para>当设备是非直连设备时，gatewayId为设备所关联的直连设备（即网关）的deviceId。</para>
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 设备类型。
        /// </summary>
        public NodeType NodeType { get; set; }

        /// <summary>
        /// 设备信息
        /// </summary>
        public DeviceInfo DeviceInfo { get; set; }
    }
}
