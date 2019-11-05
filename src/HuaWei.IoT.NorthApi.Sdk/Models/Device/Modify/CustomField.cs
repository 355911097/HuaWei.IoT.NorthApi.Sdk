namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Modify
{
    /// <summary>
    /// 自定义字段
    /// </summary>
    public class CustomField
    {
        /// <summary>
        /// 字段名字
        /// <para>可选</para>
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段类型
        /// <para>可选</para>
        /// </summary>
        public string FieldType { get; set; }

        /// <summary>
        /// 字段值
        /// <para>可选</para>
        /// </summary>
        public object FieldValue { get; set; }
    }
}
