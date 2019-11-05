using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Query
{
    /// <summary>
    /// 批量查询设备信息模型
    /// </summary>
    public class DeviceInfoQueryModel : NorthApiQueryPaging
    {
        /// <summary>
        /// 网关ID，用于标识一个网关设备。
        /// <para>当设备是直连设备时，gatewayId与设备的deviceId一致。</para>
        /// <para>当设备是非直连设备时，gatewayId为设备所关联的直连设备（即网关）的deviceId。</para>
        /// <para>“gatewayId”与“pageNo”不能同时为空。</para>
        /// <para>可选</para>
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 节点类型，取值：ENDPOINT/GATEWAY/UNKNOW。
        /// <para>可选</para>
        /// </summary>
        public NodeType? NodeType { get; set; }

        /// <summary>
        /// 设备类型。
        /// <para>可选</para>
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 设备位置信息。
        /// <para>可选</para>
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 设备名称。
        /// <para>可选</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设备状态
        /// <para>可选</para>
        /// </summary>
        public DeviceStatus? Status { get; set; }

        /// <summary>
        /// 指定返回记录，可取值：imsi。
        /// </summary>
        public string Select { get; set; } = "imsi";
    }
}
