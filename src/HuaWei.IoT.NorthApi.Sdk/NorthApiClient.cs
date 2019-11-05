using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HuaWei.IoT.NorthApi.Sdk.Enums;
using HuaWei.IoT.NorthApi.Sdk.Internal;
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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HuaWei.IoT.NorthApi.Sdk
{
    public class NorthApiClient : INorthApiClient
    {
        private readonly ILogger _logger;
        private readonly NorthApiOptions _options;
        private readonly HttpHandler _httpHandler;
        private readonly Urls _urls;
        private NorthApiToken _token;

        public NorthApiClient(ILoggerFactory loggerFactory, NorthApiOptions options)
        {
            _logger = loggerFactory?.CreateLogger(typeof(NorthApiClient));
            _options = options;
            _httpHandler = new HttpHandler(loggerFactory, options);
            _urls = new Urls(options);

            //启动时获取一次令牌
            GetToken().GetAwaiter().GetResult();

            //定时刷新令牌
            RefreshTokenTimer();
        }

        /// <summary>
        /// 刷新令牌定时器
        /// </summary>
        private void RefreshTokenTimer()
        {
            if (_options.RefreshTokenTimer)
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        //刷新间隔90分钟
                        Thread.Sleep(5400000);

                        RefreshToken().GetAwaiter().GetResult();
                    }
                });
            }
        }

        public async Task<NorthApiResult<NorthApiToken>> GetToken()
        {
            var result = new NorthApiResult<NorthApiToken>();

            var data = $"appId={_options.AppId}&secret={_options.Secret}";
            var httpResult = await _httpHandler.PostForm(_urls.Login, data);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = _token = JsonConvert.DeserializeObject<NorthApiToken>(httpResult.Content);

                _httpHandler.RefreshAuth(_token);

                _logger?.LogDebug("GetToken：{@Token}", _token);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("GetToken：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<NorthApiToken>> RefreshToken()
        {
            var result = new NorthApiResult<NorthApiToken>();
            var data = new
            {
                _options.AppId,
                _options.Secret,
                _token.RefreshToken
            };
            var httpResult = await _httpHandler.PostJson(_urls.RefreshToken, data);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = _token = JsonConvert.DeserializeObject<NorthApiToken>(httpResult.Content);

                _httpHandler.RefreshAuth(_token);

                _logger?.LogDebug("RefreshToken：{@Token}", _token);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("RefreshToken：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<DeviceRegisterResult>> DeviceRegister(DeviceRegisterModel model)
        {
            var result = new NorthApiResult<DeviceRegisterResult>();
            if (model == null)
            {
                result.Msg = "注册信息不能为空";
                return result;
            }
            if (model.NodeId.IsNull())
            {
                result.Msg = "NodeId不能为空";
                return result;
            }

            if (model.DeviceInfo?.Model == null)
            {
                result.Msg = "设备信息不能为空";
                return result;
            }

            var url = $"{_urls.DeviceRegister}?appId={_options.AppId}";
            var httpResult = await _httpHandler.PostJson(url, model);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<DeviceRegisterResult>(httpResult.Content);

                _logger?.LogDebug("DeviceRegister：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceRegister：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<DeviceRegisterForPwdResult>> DeviceRegisterForPwd(DeviceRegisterForPwdModel model)
        {
            var result = new NorthApiResult<DeviceRegisterForPwdResult>();
            var url = $"{_urls.DeviceRegister}?appId={_options.AppId}";
            var httpResult = await _httpHandler.PostJson(url, model);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<DeviceRegisterForPwdResult>(httpResult.Content);

                _logger?.LogDebug("DeviceRegisterForPwd：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceRegisterForPwd：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<DeviceRefreshResult>> DeviceRefresh(DeviceRefreshModel model)
        {
            var result = new NorthApiResult<DeviceRefreshResult>();
            if (model == null)
            {
                result.Msg = "参数不能为空";
                return result;
            }
            if (model.DeviceId.IsNull())
            {
                result.Msg = "DeviceId不能为空";
                return result;
            }

            var url = $"{_urls.DeviceRefresh}/{model.DeviceId}";
            var httpResult = await _httpHandler.PutJson(url, model);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<DeviceRefreshResult>(httpResult.Content);

                _logger?.LogDebug("DeviceRefresh：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceRefresh：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult> DeviceModify(DeviceModifyModel model)
        {
            var result = new NorthApiResult();
            if (model == null)
            {
                result.Msg = "参数不能为空";
                return result;
            }

            if (model.DeviceId.IsNull())
            {
                result.Msg = "DeviceId不能为空";
                return result;
            }

            var url = $"{_urls.DeviceModify}/{model.DeviceId}";
            var httpResult = await _httpHandler.PutJson(url, model);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.NoContent)
            {
                result.Success = true;
                _logger?.LogDebug("DeviceModify：{@Result}", result.Success);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceModify：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult> DeviceDelete(string deviceId, bool cascade = true)
        {
            var result = new NorthApiResult();
            if (deviceId.IsNull())
            {
                result.Msg = "deviceId不能为空";
                return result;
            }

            var url = $"{_urls.DeviceDelete}/{deviceId}?appId={_options.AppId}&cascade={(cascade ? "true" : "false")}";
            var httpResult = await _httpHandler.Delete(url);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.NoContent)
            {
                result.Success = true;
                _logger?.LogDebug("DeviceDelete：{@Result}", result.Success);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceDelete：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<DeviceActivatedResult>> DeviceActivated(string deviceId)
        {
            var result = new NorthApiResult<DeviceActivatedResult>();
            if (deviceId.IsNull())
            {
                result.Msg = "deviceId不能为空";
                return result;
            }

            var url = $"{_urls.DeviceActivated}/{deviceId}";
            var httpResult = await _httpHandler.Get(url);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<DeviceActivatedResult>(httpResult.Content);
                _logger?.LogDebug("DeviceDelete：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceDelete：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<DeviceInfoGetResult>> DeviceGet(string deviceId, string @select = "imsi")
        {
            var result = new NorthApiResult<DeviceInfoGetResult>();
            if (deviceId.IsNull())
            {
                result.Msg = "deviceId不能为空";
                return result;
            }

            if (select != "imsi")
            {
                result.Msg = "select仅支持imsi";
                return result;
            }

            var url = $"{_urls.DeviceGet}/{deviceId}";
            var httpResult = await _httpHandler.Get(url);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<DeviceInfoGetResult>(httpResult.Content);
                _logger?.LogDebug("DeviceGet：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceGet：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<DeviceInfoQueryResult>> DeviceQuery(DeviceInfoQueryModel model)
        {
            var result = new NorthApiResult<DeviceInfoQueryResult>();
            var urlBuilder = new StringBuilder($"{_urls.DeviceQuery}?pageNo={model.PageNo}&pageSize={model.PageSize}&");

            #region ==构造条件

            if (model.GatewayId.NotNull())
            {
                urlBuilder.AppendFormat("gatewayId={0}&", model.GatewayId);
            }

            if (model.DeviceType.NotNull())
            {
                urlBuilder.AppendFormat("deviceType={0}&", model.DeviceType);
            }

            if (model.NodeType != null)
            {
                urlBuilder.AppendFormat("nodeType={0}&", model.NodeType.Value.ToString().FirstCharToLower());
            }

            if (model.Location.NotNull())
            {
                urlBuilder.AppendFormat("location={0}&", model.Location);
            }

            if (model.Name.NotNull())
            {
                urlBuilder.AppendFormat("name={0}&", model.Name);
            }

            if (model.Status != null)
            {
                urlBuilder.AppendFormat("status={0}&", model.Status.Value.ToString().ToUpper());
            }

            if (model.StartTime != null)
            {
                urlBuilder.AppendFormat("startTime={0}&", model.StartTime.Value.ToUniversalTime().ToString("yyyyMMdd'T'HHmmss'Z'"));
            }

            if (model.EndTime != null)
            {
                urlBuilder.AppendFormat("endTime={0}&", model.EndTime.Value.ToUniversalTime().ToString("yyyyMMdd'T'HHmmss'Z'"));
            }

            if (model.Sort.NotNull())
            {
                urlBuilder.AppendFormat("sort={0}&", model.Sort.ToUpper());
            }

            #endregion

            var httpResult = await _httpHandler.Get(urlBuilder.ToString());
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<DeviceInfoQueryResult>(httpResult.Content);
                _logger?.LogDebug("DeviceGet：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceGet：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<DeviceDataHistoryQueryResult>> DeviceDataHistory(DeviceDataHistoryQueryModel model)
        {
            var result = new NorthApiResult<DeviceDataHistoryQueryResult>();
            if (model == null || model.DeviceId.IsNull())
            {
                result.Msg = "deviceId不能为空";
                return result;
            }
            var urlBuilder = new StringBuilder(_urls.DeviceDataHistory);
            urlBuilder.AppendFormat("?deviceId={0}&pageNo={1}&pageSize={2}&", model.DeviceId, model.PageNo, model.PageSize);
            if (model.GatewayId.NotNull())
            {
                urlBuilder.AppendFormat("gatewayId={0}&", model.GatewayId);
            }

            if (model.StartTime != null)
            {
                urlBuilder.AppendFormat("startTime={0}&", model.StartTime.Value.ToUniversalTime().ToString("yyyyMMdd'T'HHmmss'Z'"));
            }

            if (model.EndTime != null)
            {
                urlBuilder.AppendFormat("endTime={0}&", model.EndTime.Value.ToUniversalTime().ToString("yyyyMMdd'T'HHmmss'Z'"));
            }

            var httpResult = await _httpHandler.Get(urlBuilder.ToString());
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<DeviceDataHistoryQueryResult>(httpResult.Content);
                _logger?.LogDebug("DeviceDataHistory：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceDataHistory：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<SubscribeResult>> Subscribe(SubscribeModel model)
        {
            var result = new NorthApiResult<SubscribeResult>();
            if (model == null)
            {
                result.Msg = "订阅信息不能为空";
                return result;
            }

            var httpResult = await _httpHandler.PostJson(_urls.Subscribe, model);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.Created)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<SubscribeResult>(httpResult.Content);
                _logger?.LogDebug("Subscribe：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("Subscribe：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<SubscriptionModel>> SubscriptionGet(string subscriptionId)
        {
            var result = new NorthApiResult<SubscriptionModel>();
            if (subscriptionId.IsNull())
            {
                result.Msg = "订阅ID不能为空";
                return result;
            }

            var url = $"{_urls.SubscriptionGet}/{subscriptionId}";
            var httpResult = await _httpHandler.Get(url);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<SubscriptionModel>(httpResult.Content);
                _logger?.LogDebug("SubscriptionGet：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("SubscriptionGet：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<SubscriptionQueryResult>> SubscriptionQuery(SubscriptionQueryModel model)
        {
            var result = new NorthApiResult<SubscriptionQueryResult>();
            var urlBuilder = new StringBuilder(_urls.SubscriptionQuery);
            if (model != null)
            {
                urlBuilder.AppendFormat("?pageNo={0}&pageSize={1}&", model.PageNo, model.PageSize);

                if (model.NotifyType != null)
                {
                    urlBuilder.AppendFormat("notifyType={0}&", model.NotifyType.ToString().FirstCharToLower());
                }
            }

            var httpResult = await _httpHandler.Get(urlBuilder.ToString());
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<SubscriptionQueryResult>(httpResult.Content);
                _logger?.LogDebug("SubscriptionQuery：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("SubscriptionQuery：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult> SubscriptionDelete(string subscriptionId)
        {
            var result = new NorthApiResult();
            if (subscriptionId.IsNull())
            {
                result.Msg = "deviceId不能为空";
                return result;
            }

            var url = $"{_urls.SubscriptionDelete}/{subscriptionId}?appId={_options.AppId}";
            var httpResult = await _httpHandler.Delete(url);
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.NoContent)
            {
                result.Success = true;
                _logger?.LogDebug("SubscriptionDelete：{@Result}", result.Success);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("SubscriptionDelete：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult> SubscriptionDelete(SubscriptionDeleteModel model)
        {
            var result = new NorthApiResult();
            var urlBuilder = new StringBuilder(_urls.SubscriptionDelete);
            urlBuilder.Append("?");
            if (model != null)
            {
                if (model.NotifyType != null)
                {
                    urlBuilder.AppendFormat("notifyType={0}&", model.NotifyType.ToString().FirstCharToLower());
                }

                if (model.CallbackUrl.NotNull())
                {
                    urlBuilder.AppendFormat("callbackUrl={0}&", model.CallbackUrl);
                }

                if (model.Channel != null)
                {
                    urlBuilder.AppendFormat("channel={0}", model.Channel.ToString().ToUpper());
                }
            }

            var httpResult = await _httpHandler.Delete(urlBuilder.ToString());
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.NoContent)
            {
                result.Success = true;
                _logger?.LogDebug("SubscriptionDelete：{@Result}", result.Success);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("SubscriptionDelete：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult> Subscribe(NotifyType notifyType, string callbackUrl)
        {
            var result = new NorthApiResult<SubscribeResult>();
            if (callbackUrl.IsNull())
            {
                result.Msg = "回调地址不能为空";
                return result;
            }
            if (notifyType != NotifyType.SwUpgradeResultNotify && notifyType != NotifyType.SwUpgradeStateChangeNotify && notifyType != NotifyType.FwUpgradeStateChangeNotify && notifyType != NotifyType.FwUpgradeResultNotify)
            {
                result.Msg = "通知类型有误";
                return result;
            }

            var httpResult = await _httpHandler.PostJson(_urls.SubscribeManage, new
            {
                notifyType,
                callbackUrl
            });

            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                _logger?.LogDebug("SubscribeManage：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("SubscribeManage：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<CommandModel>> CommandCreate(CommandCreateModel model)
        {
            var result = new NorthApiResult<CommandModel>();

            #region ==参数验证==

            if (model == null || model.DeviceId.IsNull())
            {
                result.Msg = "设备编号不能为空";
                return result;
            }

            if (model.Command == null)
            {
                result.Msg = "下发命令的信息不能为空";
                return result;
            }

            if (model.Command.ServiceId.IsNull())
            {
                result.Msg = "命令对应的服务ID不能为空";
                return result;
            }


            if (model.Command.Method.IsNull())
            {
                result.Msg = "命令服务下具体的命令名称不能为空";
                return result;
            }


            if (model.Command.Paras == null)
            {
                result.Msg = "命令参数不能为空";
                return result;
            }

            #endregion

            var httpResult = await _httpHandler.PostJson(_urls.CommandCreate, model);

            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.Created)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<CommandModel>(httpResult.Content);
                _logger?.LogDebug("CommandCreate：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("CommandCreate：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<CommandQueryResult>> CommandQuery(CommandQueryModel model = null)
        {
            var result = new NorthApiResult<CommandQueryResult>();
            if (model == null)
                model = new CommandQueryModel();

            var urlBuilder = new StringBuilder(_urls.CommandQuery);
            urlBuilder.AppendFormat("?pageNo={0}&pageSize={1}", model.PageNo, model.PageSize);
            if (model.DeviceId.NotNull())
            {
                urlBuilder.AppendFormat("deviceId={0}&", model.DeviceId);
            }

            if (model.StartTime != null)
            {
                urlBuilder.AppendFormat("startTime={0}&", model.StartTime.Value.ToUniversalTime().ToString("yyyyMMdd'T'HHmmss'Z'"));
            }

            if (model.EndTime != null)
            {
                urlBuilder.AppendFormat("endTime={0}&", model.EndTime.Value.ToUniversalTime().ToString("yyyyMMdd'T'HHmmss'Z'"));
            }

            var httpResult = await _httpHandler.Get(urlBuilder.ToString());
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<CommandQueryResult>(httpResult.Content);
                _logger?.LogDebug("DeviceGet：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("DeviceGet：{@Error}", result.Error);
            }

            return result;
        }

        public async Task<NorthApiResult<CommandModel>> CommandCancel(string deviceCommandId)
        {
            var result = new NorthApiResult<CommandModel>();
            if (deviceCommandId.IsNull())
            {
                result.Msg = "命令ID不能为空";
                return result;
            }

            var url = $"{_urls.CommandCancel}/{deviceCommandId}";

            var httpResult = await _httpHandler.PutJson(url, new
            {
                status = "CANCELED"
            });
            result.StatusCode = httpResult.StatusCode;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                result.Success = true;
                result.Data = JsonConvert.DeserializeObject<CommandModel>(httpResult.Content);
                _logger?.LogDebug("CommandCancel：{@Result}", result.Data);
            }
            else
            {
                result.Error = JsonConvert.DeserializeObject<HttpError>(httpResult.Content);
                _logger?.LogDebug("CommandCancel：{@Error}", result.Error);
            }

            return result;
        }
    }
}
