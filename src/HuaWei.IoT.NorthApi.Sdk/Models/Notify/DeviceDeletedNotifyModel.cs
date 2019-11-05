namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备删除通知
    /// </summary>
    public class DeviceDeletedNotifyModel : BaseNotifyModel
    {
        /// <summary>
        /// 网关ID，用于标识一个网关设备
        /// </summary>
        public string GatewayId { get; set; }
    }
}
