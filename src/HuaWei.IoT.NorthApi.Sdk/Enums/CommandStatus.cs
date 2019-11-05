namespace HuaWei.IoT.NorthApi.Sdk.Enums
{
    /// <summary>
    /// 命令状态
    /// </summary>
    public enum CommandStatus
    {
        /// <summary>
        /// 缓存未下发
        /// </summary>
        Pending,
        /// <summary>
        /// 已经过期
        /// </summary>
        Expired,
        /// <summary>
        /// 已经成功执行
        /// </summary>
        Successful,
        /// <summary>
        /// 执行失败
        /// </summary>
        Failed,
        /// <summary>
        /// 超时
        /// </summary>
        Timeout,
        /// <summary>
        /// 已经被撤销执行
        /// </summary>
        Canceled,
        /// <summary>
        /// 已送达设备
        /// </summary>
        Delivered,
        /// <summary>
        /// 正在下发
        /// </summary>
        Sent
    }
}
