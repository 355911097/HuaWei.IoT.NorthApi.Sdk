namespace HuaWei.IoT.NorthApi.Sdk.Models.Command
{
    /// <summary>
    /// 命令内容
    /// </summary>
    public class CommandBody
    {
        /// <summary>
        /// 命令对应的服务ID，用于标识一个服务。要与profile中定义的serviceId保持一致。
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// 命令服务下具体的命令名称，要与profile中定义的命令名保持一致。
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 命令参数，jsonString格式，里面是一个个健值对（key: value）
        /// <para>“key”是产品模型中命令参数的参数名（paraName），“value”是该命令参数要设置的值，根据产品模型中命令参数的取值范围自定义设置。</para>
        /// </summary>
        public object Paras { get; set; }
    }
}
