namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备服务能力删除通知模型
    /// </summary>
    public class DeviceCapabilitiesDeletedNotifyModel : BaseNotifyModel
    {
        /// <summary>
        /// 设备的类型。
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 设备模型的厂商ID。
        /// </summary>
        public string ManufacturerId { get; set; }

        /// <summary>
        /// 设备模型的厂商名称。
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 设备型号。
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 设备使用的协议类型。
        /// </summary>
        public string ProtocolType { get; set; }
    }
}
