namespace HuaWei.IoT.NorthApi.Sdk.Enums
{
    /// <summary>
    /// 订阅业务数据通知类型
    /// </summary>
    public enum NotifyType
    {
        /// <summary>
        /// 添加新设备，订阅后推送注册设备通知
        /// </summary>
        DeviceAdded,
        /// <summary>
        /// 绑定设备，订阅后推送绑定设备通知
        /// </summary>
        BindDevice,
        /// <summary>
        /// 设备信息变化，订阅后推送设备信息变化通知
        /// </summary>
        DeviceInfoChanged,
        /// <summary>
        /// 设备数据变化，订阅后推送设备数据变化通知
        /// </summary>
        DeviceDataChanged,
        /// <summary>
        /// 设备数据批量变化，订阅后推送批量设备数据变化通知
        /// </summary>
        DeviceDatasChanged,
        /// <summary>
        /// 设备服务能力变化，订阅后推送设备服务能力变化通知
        /// </summary>
        DeviceCapabilitiesChanged,
        /// <summary>
        /// 设备服务能力增加，订阅后推送设备服务能力增加通知
        /// </summary>
        DeviceCapabilitiesAdded,
        /// <summary>
        /// 设备服务能力删除，订阅后推送设备服务能力删除通知
        /// </summary>
        DeviceCapabilitiesDeleted,
        /// <summary>
        /// 删除设备，订阅后推送删除设备通知
        /// </summary>
        DeviceDeleted,
        /// <summary>
        /// 消息确认，订阅后推送设备消息确认通知。仅适用于使用MQTT协议接入的设备。
        /// </summary>
        MessageConfirm,
        /// <summary>
        /// 命令响应，订阅后推送设备命令响应通知。仅适用于使用MQTT协议接入的设备。
        /// </summary>
        CommandRsp,
        /// <summary>
        /// 规则事件，订阅后推送规则事件通知
        /// </summary>
        RuleEvent,
        /// <summary>
        /// 设备影子状态变更，订阅后推送设备影子状态变更通知
        /// </summary>
        DeviceDesiredPropertiesModifyStatusChanged,
        /// <summary>
        /// 软件升级状态变更通知，订阅后推送软件升级状态变更通知
        /// </summary>
        SwUpgradeStateChangeNotify,
        /// <summary>
        /// 软件升级结果通知，订阅后推送软件升级结果通知
        /// </summary>
        SwUpgradeResultNotify,
        /// <summary>
        /// 固件升级状态变更通知，订阅后推送固件升级状态变更通知
        /// </summary>
        FwUpgradeStateChangeNotify,
        /// <summary>
        /// 固件升级结果通知，订阅后推送固件升级结果通知
        /// </summary>
        FwUpgradeResultNotify
    }
}
