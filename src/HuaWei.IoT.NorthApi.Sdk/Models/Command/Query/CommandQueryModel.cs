namespace HuaWei.IoT.NorthApi.Sdk.Models.Command.Query
{
    /// <summary>
    /// 命令查询模型
    /// </summary>
    public class CommandQueryModel : NorthApiQueryPaging
    {
        /// <summary>
        /// 指定查询命令的设备ID，用于唯一标识一个设备，在注册设备时由物联网平台分配获得。
        /// <para>可选</para>
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 命令所属的应用ID，当查询授权应用下的命令时才需要填写。
        /// </summary>
        public string AppId { get; set; }
    }
}
