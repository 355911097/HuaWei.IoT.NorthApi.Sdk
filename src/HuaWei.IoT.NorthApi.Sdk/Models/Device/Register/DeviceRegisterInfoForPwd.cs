namespace HuaWei.IoT.NorthApi.Sdk.Models.Device.Register
{
    /// <summary>
    /// 设备信息(密码方式)
    /// </summary>
    public class DeviceRegisterInfoForPwd : DeviceRegisterInfo
    {
        /// <summary>
        /// 设备唯一标识码，必须与设备上报的设备标识一致。通常使用MAC地址，Serial No或IMEI作为nodeId。
        /// <para>必选</para>
        /// </summary>
        public string NodeId { get; set; }
    }
}
