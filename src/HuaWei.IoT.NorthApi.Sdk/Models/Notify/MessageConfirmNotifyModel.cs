using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 设备消息确认通知模型
    /// </summary>
    public class MessageConfirmNotifyModel
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public NotifyType NotifyType { get; set; }

        /// <summary>
        /// 消息头
        /// </summary>
        public MessageConfirmHeader Header { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        public object Body { get; set; }
    }

    /// <summary>
    /// 设备消息确认通知头
    /// </summary>
    public class MessageConfirmHeader
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
        /// 命令状态。
        /// <para>sent：已发送</para>
        /// </summary>
        public MessageStatus Status { get; set; }

        /// <summary>
        /// 消息发送的UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// </summary>
        public string Timestamp { get; set; }
    }
}
