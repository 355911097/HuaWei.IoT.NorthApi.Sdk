namespace HuaWei.IoT.NorthApi.Sdk.Models.Command.Create
{
    /// <summary>
    /// 命令创建模型
    /// </summary>
    public class CommandCreateModel
    {
        /// <summary>
        /// 下发命令的设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// <para>必选</para>
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 下发命令的信息。
        /// <para>必选</para>
        /// </summary>
        public CommandBody Command { get; set; }

        /// <summary>
        /// 命令状态变化通知地址，当命令状态变化时（执行失败，执行成功，超时，发送，已送达）会通知应用服务器。
        /// <para>可选</para>
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 下发命令的有效时间，单位为秒,表示设备命令在创建后expireTime秒内有效，超过这个时间范围后命令将不再下发，如果未设置则默认为48小时（86400s*2）。
        /// <para>如果expireTime设置为0，则无论物联网平台上设置的命令下发模式是什么，该命令都会立即下发给设备（如果设备处于休眠状态或者链路已老化，则设备收不到命令，平台没收到设备的响应，该命令最终会超时）。</para>
        /// <para>如果expireTime不为0，则在expireTime时间内命令缓存在平台（PENDING状态），仅当设备上线或向平台上报数据时，命令会下发给设备。</para>
        /// <para>可选</para>
        /// </summary>
        public int ExpireTime { get; set; }

        /// <summary>
        /// 命令下发最大重传次数。
        /// <para>可选</para>
        /// </summary>
        public int MaxRetransmit { get; set; }
    }
}
