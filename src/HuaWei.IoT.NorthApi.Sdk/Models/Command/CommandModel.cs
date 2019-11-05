using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Command
{
    /// <summary>
    /// 命令信息
    /// </summary>
    public class CommandModel
    {
        /// <summary>
        /// 设备命令ID，用于唯一标识一条命令，在下发设备命令时由物联网平台分配获得
        /// </summary>
        public string CommandId { get; set; }

        /// <summary>
        /// 设备命令所属应用ID。
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 下发命令的设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 下发命令的信息。
        /// </summary>
        public CommandBody Command { get; set; }

        /// <summary>
        /// 命令状态变化通知地址，当命令状态变化时（执行失败，执行成功，超时，发送，已送达）会通知应用服务器。
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 下发命令的超时时间，单位为秒，表示设备命令在创建后expireTime秒内有效，超过这个时间范围后命令将不再下发，如果未设置则默认为48小时（86400s*2）。
        /// </summary>
        public int ExpireTime { get; set; }

        /// <summary>
        /// 命令状态
        /// </summary>
        public CommandStatus Status { get; set; }

        /// <summary>
        /// 命令创建的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// 命令执行的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// </summary>
        public string ExecuteTime { get; set; }

        /// <summary>
        /// 平台发送命令的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// </summary>
        public string PlatformIssuedTime { get; set; }

        /// <summary>
        /// 平台将命令送达到设备的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// </summary>
        public string DeliveredTime { get; set; }

        /// <summary>
        /// 平台发送命令的次数。
        /// </summary>
        public int IssuedTimes { get; set; }

        /// <summary>
        /// 命令下发最大重传次数。
        /// </summary>
        public int MaxRetransmit { get; set; }
    }
}
