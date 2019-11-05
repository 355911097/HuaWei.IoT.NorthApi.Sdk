namespace HuaWei.IoT.NorthApi.Sdk.Internal
{
    /// <summary>
    /// 接口地址信息
    /// </summary>
    internal class Urls
    {
        /// <summary>
        /// 鉴权
        /// </summary>
        public readonly string Login;

        /// <summary>
        /// 刷新令牌
        /// </summary>
        public readonly string RefreshToken;

        /// <summary>
        /// 设备注册
        /// </summary>
        public readonly string DeviceRegister;

        /// <summary>
        /// 注册设备（密码方式）
        /// </summary>
        public readonly string DeviceRegisterForPwd;

        /// <summary>
        /// 刷新设备密钥
        /// </summary>
        public readonly string DeviceRefresh;

        /// <summary>
        /// 修改设备信息
        /// </summary>
        public readonly string DeviceModify;

        /// <summary>
        /// 删除设备
        /// </summary>
        public readonly string DeviceDelete;

        /// <summary>
        /// 查询设备激活状态
        /// </summary>
        public readonly string DeviceActivated;

        /// <summary>
        /// 查询单个设备信息
        /// </summary>
        public readonly string DeviceGet;

        /// <summary>
        /// 批量查询设备信息
        /// </summary>
        public readonly string DeviceQuery;

        /// <summary>
        /// 查询设备历史数据
        /// </summary>
        public readonly string DeviceDataHistory;

        /// <summary>
        /// 订阅平台业务数据
        /// </summary>
        public readonly string Subscribe;

        /// <summary>
        /// 查询单个订阅
        /// </summary>
        public readonly string SubscriptionGet;

        /// <summary>
        /// 批量查询订阅
        /// </summary>
        public readonly string SubscriptionQuery;

        /// <summary>
        /// 删除单个订阅
        /// </summary>
        public readonly string SubscriptionDelete;

        /// <summary>
        /// 订阅平台管理数据
        /// </summary>
        public readonly string SubscribeManage;

        /// <summary>
        /// 创建设备命令
        /// </summary>
        public readonly string CommandCreate;

        /// <summary>
        /// 查询设备命令
        /// </summary>
        public readonly string CommandQuery;

        /// <summary>
        /// 撤销命令
        /// </summary>
        public readonly string CommandCancel;

        public Urls(NorthApiOptions options)
        {
            Login = $"{options.BaseUrl}/iocm/app/sec/v1.1.0/login";
            RefreshToken = $"{options.BaseUrl}/iocm/app/sec/v1.1.0/refreshToken";
            DeviceRegister = $"{options.BaseUrl}/iocm/app/reg/v1.1.0/deviceCredentials";
            DeviceRegisterForPwd = $"{options.BaseUrl}/iocm/app/reg/v2.0.0/deviceCredentials";
            DeviceRefresh = $"{options.BaseUrl}/iocm/app/reg/v1.1.0/deviceCredentials";
            DeviceModify = $"{options.BaseUrl}/iocm/app/dm/v1.4.0/devices";
            DeviceDelete = $"{options.BaseUrl}/iocm/app/dm/v1.4.0/devices";
            DeviceActivated = $"{options.BaseUrl}/iocm/app/reg/v1.1.0/deviceCredentials";
            DeviceGet = $"{options.BaseUrl}/iocm/app/dm/v1.4.0/devices";
            DeviceQuery = $"{options.BaseUrl}/iocm/app/dm/v1.4.0/devices";
            DeviceDataHistory = $"{options.BaseUrl}/iocm/app/data/v1.2.0/deviceDataHistory";
            Subscribe = $"{options.BaseUrl}/iocm/app/sub/v1.2.0/subscriptions";
            SubscriptionGet = $"{options.BaseUrl}/iocm/app/sub/v1.2.0/subscriptions";
            SubscriptionQuery = $"{options.BaseUrl}/iocm/app/sub/v1.2.0/subscriptions";
            SubscriptionDelete = $"{options.BaseUrl}/iocm/app/sub/v1.2.0/subscriptions";
            SubscribeManage = $"{options.BaseUrl}/iodm/app/sub/v1.1.0/subscribe";
            CommandCreate = $"{options.BaseUrl}/iocm/app/cmd/v1.4.0/deviceCommands";
            CommandQuery = $"{options.BaseUrl}/iocm/app/cmd/v1.4.0/deviceCommands";
            CommandCancel = $"{options.BaseUrl}/iocm/app/cmd/v1.4.0/deviceCommands/";
        }
    }
}
