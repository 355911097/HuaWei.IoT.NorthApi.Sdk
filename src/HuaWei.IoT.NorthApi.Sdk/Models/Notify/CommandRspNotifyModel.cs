using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备命令响应通知模型
    /// </summary>
    public class CommandRspNotifyModel
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public NotifyType NotifyType { get; set; }

        /// <summary>
        /// 消息头
        /// </summary>
        public CommandRspHeader Header { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        public object Body { get; set; }
    }

    /// <summary>
    /// 设备命令响应头
    /// </summary>
    public class CommandRspHeader
    {
        /// <summary>
        /// 消息的序列号，唯一标识该消息。
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 表示消息发布者的地址。
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 表示消息接收者的地址
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 命令所属的服务类型。
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// 存放的响应命令，如：INVITE-RSP。
        /// </summary>
        public string Method { get; set; }
    }
}
