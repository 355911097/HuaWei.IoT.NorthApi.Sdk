namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 命令状态变化通知模型
    /// </summary>
    public class CommandChangedNotifyModel
    {
        /// <summary>
        /// 设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 设备命令ID，用于唯一标识一条命令，在下发设备命令时由物联网平台分配获得。
        /// </summary>
        public string CommandId { get; set; }

        /// <summary>
        /// 命令状态信息
        /// </summary>
        public CommandResultForDevice Result { get; set; }
    }

    /// <summary>
    /// 命令状态信息
    /// </summary>
    public class CommandResultForDevice
    {
        /// <summary>
        /// 命令状态。
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// 命令结果详细信息。
        /// </summary>
        public object ResultDetail { get; set; }
    }
}
