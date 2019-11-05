using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Register
{
    /// <summary>
    /// 设备信息(验证码方式)
    /// </summary>
    public class DeviceRegisterInfo
    {
        /// <summary>
        /// 厂商ID，唯一标识一个厂商。与manufacturerName、deviceType、model和protocolType参数一起用于关联设备所属的产品模型，与productId参数二选一。
        /// <para>可选</para>
        /// </summary>
        public string ManufacturerId { get; set; }

        /// <summary>
        /// 厂商名称。与manufacturerId、deviceType、model和protocolType参数一起用于关联设备所属的产品模型，与productId参数二选一。
        /// <para>可选</para>
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 设备类型，大驼峰命名方式，如MultiSensor、ContactSensor、CameraGateway。
        /// <para>与manufacturerId、manufacturerName、model和protocolType参数一起用于关联设备所属的产品模型，与productId参数二选一。</para>
        /// <para>可选</para>
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 设备的型号。
        /// <para>与manufacturerId、manufacturerName、deviceType和protocolType参数一起用于关联设备所属的产品模型，与productId参数二选一。</para>
        /// <para>必选</para>
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 设备使用的协议类型，当前支持的协议类型：CoAP，LWM2M。
        /// <para>与manufacturerId、manufacturerName、deviceType和model参数一起用于关联设备所属的产品模型，与productId参数二选一。</para>
        /// <para>可选</para>
        /// </summary>
        public ProtocolType ProtocolType { get; set; }

        /// <summary>
        /// 设备名称。
        /// <para>可选</para>
        /// </summary>
        public string Name { get; set; }
    }
}
