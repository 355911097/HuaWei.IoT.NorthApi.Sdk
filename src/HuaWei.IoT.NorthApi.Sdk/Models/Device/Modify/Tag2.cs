namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Modify
{
    /// <summary>
    /// 设备标签
    /// </summary>
    public class Tag2
    {
        /// <summary>
        /// 标签名称。
        /// <para>必选</para>
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// 标签值
        /// <para>必选</para>
        /// </summary>
        public string TagValue { get; set; }

        /// <summary>
        /// 标签类型
        /// <para>可选</para>
        /// </summary>
        public int? TagType { get; set; }
    }
}
