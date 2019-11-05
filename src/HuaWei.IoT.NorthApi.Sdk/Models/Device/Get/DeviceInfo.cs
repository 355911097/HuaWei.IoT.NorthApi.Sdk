using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Get
{
    /// <summary>
    /// 设备信息
    /// </summary>
    public class DeviceInfo
    {
        /// <summary>
        /// 设备唯一标识码。
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// 设备名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设备的描述信息。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 厂商ID，唯一标识一个厂商。
        /// </summary>
        public string ManufacturerId { get; set; }

        /// <summary>
        /// 厂商名称。
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 设备的MAC地址。
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// 设备的位置信息。
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 设备类型，大驼峰命名方式，如MultiSensor、ContactSensor、CameraGateway。
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 设备的型号。
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 设备的软件版本。
        /// </summary>
        public string SwVersion { get; set; }

        /// <summary>
        /// 设备的固件版本。
        /// </summary>
        public string FwVersion { get; set; }

        /// <summary>
        /// 设备的硬件版本。
        /// </summary>
        public string HwVersion { get; set; }

        /// <summary>
        /// NB-IoT终端的IMSI。
        /// </summary>
        public string Imsi { get; set; }

        /// <summary>
        /// 设备使用的协议类型。
        /// </summary>
        public ProtocolType ProtocolType { get; set; }

        /// <summary>
        /// Radius地址。
        /// </summary>
        public string RadiusIp { get; set; }

        /// <summary>
        /// Bridge标识，表示设备通过哪个Bridge接入物联网平台。
        /// </summary>
        public string BridgeId { get; set; }

        /// <summary>
        /// 设备的状态，表示设备是否在线，取值范围：ONLINE、OFFLINE、INACTIVE、ABNORMAL。
        /// <para>设备首次接入平台之前，设备的状态为INACTIVE。</para>
        /// <para>若设备超过25（默认值）小时未向平台上报数据或发送消息，则设备状态为ABNORMAL（默认值）；</para>
        /// <para>若设备超过49小时未向平台上报数据或发送消息，则设备状态为OFFLINE。</para>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 设备的状态详情，跟status取值对应。建议仅用作显示，不建议用于逻辑判断。
        /// <para>status为ONLINE时，取值范围为NONE（无），CONFIGURATION_PENDING（配置待下发），UE_REACHABILITY（设备可达），</para>
        /// <para>status为OFFLINE时，取值范围为NONE（无），COMMUNICATION_ERROR（通信故障），CONFIGURATION_ERROR（配置错误），BRIDGE_OFFLINE（Bridge离线），FIRMWARE_UPDATING（固件升级中），DUTY_CYCLE，NOT_ACTIVE（未激活），LOSS_OF_CONNECTIVITY（连接断开），TIME_OUT（超时）。</para>
        /// <para>status为INACTIVE时，取值范围为NONE（无），NOT_ACTIVE（未激活）。</para>
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// 表示设备是否处于冻结状态，即设备上报数据时，平台是否会管理和保存。
        /// <para>TRUE：冻结状态</para>
        /// <para>FALSE：非冻结状态</para>
        /// </summary>
        public string Mute { get; set; }

        /// <summary>
        /// 表示设备是否支持安全模式。
        /// <para>TRUE：支持安全模式</para>
        /// <para>FALSE：不支持安全模式</para>
        /// </summary>
        public string SupportedSecurity { get; set; }

        /// <summary>
        /// 表示设备当前是否启用安全模式。
        /// <para>TRUE：启用</para>
        /// <para>FALSE：未启用</para>
        /// </summary>
        public string IsSecurity { get; set; }

        /// <summary>
        /// 设备的信号强度。
        /// </summary>
        public string SignalStrength { get; set; }

        /// <summary>
        /// 设备的sig版本。
        /// </summary>
        public string SigVersion { get; set; }

        /// <summary>
        /// 设备的序列号。
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 设备的电池电量。
        /// </summary>
        public string BatteryLevel { get; set; }
    }
}
