using System.Collections.Generic;
using HuaWei.IoT.NorthApi.Sdk.Models.Service;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备数据批量变化通知模型
    /// </summary>
    public class DeviceDatasChangedNotifyModel : BaseNotifyModel
    {
        /// <summary>
        /// 消息的序列号，唯一标识该消息。
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 网关ID
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// 设备的服务数据列表
        /// </summary>
        public List<DeviceServiceDataModel> Services { get; set; }
    }
}
