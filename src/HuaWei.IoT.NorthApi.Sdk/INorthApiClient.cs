using System.Threading.Tasks;
using HuaWei.IoT.NorthApi.Sdk.Enums;
using HuaWei.IoT.NorthApi.Sdk.Models;
using HuaWei.IoT.NorthApi.Sdk.Models.Command;
using HuaWei.IoT.NorthApi.Sdk.Models.Command.Create;
using HuaWei.IoT.NorthApi.Sdk.Models.Command.Query;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Activated;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.DataHistory;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Get;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Modify;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Query;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Refresh;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Register;
using HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Delete;
using HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Get;
using HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Query;
using HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Subscribe;

namespace HuaWei.IoT.NorthApi.Sdk
{
    /// <summary>
    /// 华为IoT平台北向API客户端
    /// </summary>
    public interface INorthApiClient
    {
        #region ==应用安全接入==

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        Task<NorthApiResult<NorthApiToken>> GetToken();

        /// <summary>
        /// 刷新令牌
        /// </summary>
        /// <returns></returns>
        Task<NorthApiResult<NorthApiToken>> RefreshToken();

        #endregion

        #region ==设备管理==

        /// <summary>
        /// 注册设备（验证码方式）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<DeviceRegisterResult>> DeviceRegister(DeviceRegisterModel model);

        /// <summary>
        /// 注册设备（密码方式）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<DeviceRegisterForPwdResult>> DeviceRegisterForPwd(DeviceRegisterForPwdModel model);

        /// <summary>
        /// 刷新设备密钥
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<DeviceRefreshResult>> DeviceRefresh(DeviceRefreshModel model);

        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult> DeviceModify(DeviceModifyModel model);

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="deviceId">设备编号</param>
        /// <param name="cascade">仅当设备下连接了非直连设备时生效。默认值为true。
        /// <para>true，级联删除，即删除直连设备和其下的非直连设备。</para>
        /// <para>false，删除直连设备，但是不删其下的非直连设备，并将非直连设备的属性变为直连设备属性。</para>
        /// </param>
        /// <returns></returns>
        Task<NorthApiResult> DeviceDelete(string deviceId, bool cascade = true);

        /// <summary>
        /// 查询设备激活状态
        /// </summary>
        /// <param name="deviceId">设备编号</param>
        /// <returns></returns>
        Task<NorthApiResult<DeviceActivatedResult>> DeviceActivated(string deviceId);

        /// <summary>
        /// 查询单个设备信息
        /// </summary>
        /// <param name="deviceId">设备编号</param>
        /// <param name="select">指定查询条件，可选值：imsi。</param>
        /// <returns></returns>
        Task<NorthApiResult<DeviceInfoGetResult>> DeviceGet(string deviceId, string select = "imsi");

        /// <summary>
        /// 批量查询设备信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<DeviceInfoQueryResult>> DeviceQuery(DeviceInfoQueryModel model);

        /// <summary>
        /// 查询设备历史数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<DeviceDataHistoryQueryResult>> DeviceDataHistory(DeviceDataHistoryQueryModel model);

        #endregion

        #region ==订阅管理==

        /// <summary>
        /// 订阅平台业务数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<SubscribeResult>> Subscribe(SubscribeModel model);

        /// <summary>
        /// 查询单个订阅
        /// </summary>
        /// <param name="subscriptionId">订阅ID，用于唯一标识一个订阅，在创建订阅时由物联网平台分配获得。</param>
        /// <returns></returns>
        Task<NorthApiResult<SubscriptionModel>> SubscriptionGet(string subscriptionId);

        /// <summary>
        /// 批量查询订阅
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<SubscriptionQueryResult>> SubscriptionQuery(SubscriptionQueryModel model);

        /// <summary>
        /// 删除单个订阅
        /// </summary>
        /// <param name="subscriptionId">订阅ID号，用于唯一标识一个订阅，在创建订阅时由物联网平台分配获得。</param>
        /// <returns></returns>
        Task<NorthApiResult> SubscriptionDelete(string subscriptionId);

        /// <summary>
        /// 批量删除订阅
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult> SubscriptionDelete(SubscriptionDeleteModel model);

        /// <summary>
        /// 订阅平台管理数据
        /// </summary>
        /// <param name="notifyType"></param>
        /// <param name="callbackUrl"></param>
        /// <returns></returns>
        Task<NorthApiResult> Subscribe(NotifyType notifyType, string callbackUrl);

        #endregion

        #region ==命令下发==

        /// <summary>
        /// 创建设备命令
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<CommandModel>> CommandCreate(CommandCreateModel model);

        /// <summary>
        /// 查询设备命令
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NorthApiResult<CommandQueryResult>> CommandQuery(CommandQueryModel model = null);

        /// <summary>
        /// 撤销设备命令
        /// </summary>
        /// <param name="deviceCommandId"></param>
        /// <returns></returns>
        Task<NorthApiResult<CommandModel>> CommandCancel(string deviceCommandId);

        #endregion
    }
}
