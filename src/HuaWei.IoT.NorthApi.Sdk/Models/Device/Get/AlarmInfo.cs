namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Get
{
    /// <summary>
    /// 设备警告信息
    /// </summary>
    public class AlarmInfo
    {
        /// <summary>
        /// 告警级别。
        /// </summary>
        public string AlarmSeverity { get; set; }

        /// <summary>
        /// 告警状态。
        /// </summary>
        public bool AlarmStatus { get; set; }

        /// <summary>
        /// 告警上报UTC时间，时间格式：yyyyMMdd'T'HHmmss'Z'，如20151212T121212Z。
        /// <para>若需要显示本地时区时间，您需要自己进行时间转换。</para>
        /// </summary>
        public string AlarmTime { get; set; }
    }
}
