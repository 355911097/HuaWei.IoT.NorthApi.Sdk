namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Activated
{
    /// <summary>
    /// 查询设备激活状态结果
    /// </summary>
    public class DeviceActivatedResult
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 激活状态，设备是否通过验证码获取密码的状态标识。
        /// </summary>
        public bool Activated { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Name { get; set; }
    }
}
