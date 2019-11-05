using System.Collections.Generic;
using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Modify
{
    /// <summary>
    /// 修改设备信息模型
    /// </summary>
    public class DeviceModifyModel
    {
        /// <summary>
        /// 设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// <para>必选</para>
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 自定义字段列表，用户可设置自定义字段。
        /// <para>可选</para>
        /// </summary>
        public List<CustomField> CustomFields { get; set; }

        /// <summary>
        /// 设备配置信息
        /// <para>可选</para>
        /// </summary>
        public DeviceConfig DeviceConfig { get; set; }

        /// <summary>
        /// 设备类型，大驼峰命名方式，例如：MultiSensor、ContactSensor、CameraGateway。
        /// <para>可选</para>
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 终端用户，若为直连设备，则endUser可选；若为非直连设备，则endUser可以为null。
        /// <para>可选</para>
        /// </summary>
        public string EndUser { get; set; }

        /// <summary>
        /// 设备位置。
        /// <para>可选</para>
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 设备所属的产品ID。
        /// <para>可选</para>
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 厂商ID，唯一标识一个厂商。
        /// <para>可选</para>
        /// </summary>
        public string ManufacturerId { get; set; }

        /// <summary>
        /// 厂商名称。
        /// <para>可选</para>
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 设备型号，由厂商定义。
        /// <para>可选</para>
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 表示设备是否处于冻结状态，即设备上报数据时，平台是否会管理和保存。
        /// <para>RUE：冻结状态</para>
        /// <para>FALSE：非冻结状态</para>
        /// <para>可选</para>
        /// </summary>
        public string Mute { get; set; }

        /// <summary>
        /// 设备名称。
        /// <para>可选</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设备所属的组织信息。
        /// <para>可选</para>
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// 设备使用的协议类型，当前支持的协议类型：CoAP，LWM2M，MQTT。
        /// <para>可选</para>
        /// </summary>
        public ProtocolType ProtocolType { get; set; }

        /// <summary>
        /// 设备区域信息
        /// <para>可选</para>
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 设备所在时区信息，使用时区编码，如Asia/Shanghai, America/New_York。
        /// <para>可选</para>
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// NB-IoT终端的IMSI。
        /// <para>可选</para>
        /// </summary>
        public string Imsi { get; set; }

        /// <summary>
        /// 设备的IP地址
        /// <para>可选</para>
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 指定设备是否为安全设备，默认值为false。在NB-IoT场景下，注册的设备为加密设备时，isSecure要设置为true。
        /// <para>可选</para>
        /// </summary>
        public bool IsSecure { get; set; }

        /// <summary>
        /// psk参数，取值范围是a-f、A-F、0-9组成的字符串。
        /// <para>可选</para>
        /// </summary>
        public string Psk { get; set; }

        /// <summary>
        /// 设备的标签信息。
        /// <para>可选</para>
        /// </summary>
        public List<Tag2> Tags { get; set; }
    }
}
