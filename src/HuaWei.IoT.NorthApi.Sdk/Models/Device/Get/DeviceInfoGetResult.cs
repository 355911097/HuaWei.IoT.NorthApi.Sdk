using System.Collections.Generic;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Get
{
    /// <summary>
    /// 单个设备信息查询结果
    /// </summary>
    public class DeviceInfoGetResult
    {
        /// <summary>
        /// 设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 网关ID，用于标识一个网关设备。
        /// <para>当设备是直连设备时，gatewayId与设备的deviceId一致。</para>
        /// <para>当设备是非直连设备时，gatewayId为设备所关联的直连设备（即网关）的deviceId。</para>
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 节点类型，取值：ENDPOINT/GATEWAY/UNKNOW。
        /// <para>可使用<see cref="T:HuaWei.IoT.NorthApi.Sdk.Const.NorthApiNodeType"/>类</para>
        /// <para>可选</para>
        /// </summary>
        public string NodeType { get; set; }

        /// <summary>
        /// 创建设备的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// <para>若需要显示本地时区时间，您需要自己进行时间转换</para>
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 最后修改设备的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// <para>若需要显示本地时区时间，您需要自己进行时间转换</para>
        /// </summary>
        public string LastModifiedTime { get; set; }

        /// <summary>
        /// 设备信息
        /// </summary>
        public DeviceInfo DeviceInfo { get; set; }

        /// <summary>
        /// 设备服务列表。
        /// </summary>
        public List<DeviceService> Services { get; set; }

        /// <summary>
        /// 设备告警信息。
        /// </summary>
        public AlarmInfo AlarmInfo { get; set; }
    }
}
