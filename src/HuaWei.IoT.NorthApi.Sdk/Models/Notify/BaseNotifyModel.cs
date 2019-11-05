using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Notify
{
    /// <summary>
    /// 基础通知模型
    /// </summary>
    public class BaseNotifyModel
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public NotifyType NotifyType { get; set; }

        /// <summary>
        /// 设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 设备所属应用的应用ID。
        /// </summary>
        public string AppId { get; set; }
    }
}
