using System.Collections.Generic;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Get;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Query
{
    /// <summary>
    /// 批量查询设备信息结果
    /// </summary>
    public class DeviceInfoQueryResult : NorthApiQueryResult
    {
        /// <summary>
        /// 设备分页列表信息。
        /// </summary>
        public List<DeviceInfoGetResult> Devices { get; set; }
    }
}
