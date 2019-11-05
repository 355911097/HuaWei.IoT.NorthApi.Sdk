using System.Collections.Generic;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Get
{
    /// <summary>
    /// 设备的服务信息
    /// </summary>
    public class ServiceInfo
    {
        /// <summary>
        /// 屏蔽的设备控制命令列表
        /// </summary>
        public List<string> MuteCmds { get; set; }
    }
}
