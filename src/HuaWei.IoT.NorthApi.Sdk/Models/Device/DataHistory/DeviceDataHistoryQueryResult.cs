using System.Collections.Generic;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.DataHistory
{
    /// <summary>
    /// 设备历史数据查询结果
    /// </summary>
    public class DeviceDataHistoryQueryResult : NorthApiQueryResult
    {
        /// <summary>
        /// 设备历史数据列表。
        /// </summary>
        public List<DeviceDataHistoryModel> DeviceDataHistoryDTOs { get; set; }
    }
}
