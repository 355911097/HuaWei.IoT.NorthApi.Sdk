namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Modify
{
    /// <summary>
    /// 数据配置信息
    /// </summary>
    public class DataConfig
    {
        /// <summary>
        /// 数据老化时长，取值范围：0-90，单位：天。
        /// <para>可选</para>
        /// </summary>
        public int DataAgingTime { get; set; }
    }
}
