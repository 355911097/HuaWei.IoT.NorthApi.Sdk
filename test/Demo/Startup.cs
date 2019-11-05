using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HuaWei.IoT.NorthApi.Sdk;
using HuaWei.IoT.NorthApi.Sdk.Enums;
using HuaWei.IoT.NorthApi.Sdk.Models.Command;
using HuaWei.IoT.NorthApi.Sdk.Models.Command.Create;
using HuaWei.IoT.NorthApi.Sdk.Models.Command.Query;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.DataHistory;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Modify;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Query;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Refresh;
using HuaWei.IoT.NorthApi.Sdk.Models.Device.Register;
using HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Query;
using HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Subscribe;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo
{
    public class Startup : IHostedService
    {
        private readonly INorthApiClient _client;
        private readonly ILogger _logger;
        private readonly string _deviceId = "a656a9a6-8f45-400b-82c5-f491de077ba0";

        public Startup(INorthApiClient client, ILogger<Startup> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //注册设备
            //await DeviceRegister();

            //刷新设备
            //await DeviceRefresh();

            //修改设备信息
            //await DeviceModify();

            //删除设别
            //await DeviceDelete();

            //查询设备激活状态
            //await DeviceActivated();

            //查询单个设备信息
            //await DeviceGet();

            //批量查询设备信息
            //await DeviceQuery();

            //查询设备历史数据
            //await DeviceDataHistory();

            //订阅平台业务数据
            //await Subscribe();

            //查询单个订阅信息
            //await SubscriptionGet();

            //批量查询订阅
            //await SubscriptionQuery();

            //删除单个订阅
            //await SubscriptionDelete();

            //创建设别命令
            //await CommandCreate();

            //查询设备命令
            //await CommandQuery();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 设备注册
        /// </summary>
        /// <returns></returns>
        private async Task DeviceRegister()
        {
            var model = new DeviceRegisterModel
            {
                EndUserId = "",
                Imsi = "",
                NodeId = "",
                Timeout = 0,
                DeviceInfo = new DeviceRegisterInfo
                {
                    DeviceType = "",
                    ManufacturerId = "",
                    ManufacturerName = "",
                    Model = "",
                    Name = "测试",
                    ProtocolType = ProtocolType.CoAP
                }
            };

            await _client.DeviceRegister(model);
        }

        /// <summary>
        /// 设备刷新
        /// </summary>
        /// <returns></returns>
        private async Task DeviceRefresh()
        {
            var model = new DeviceRefreshModel
            {
                DeviceId = _deviceId,
                NodeId = ""
            };

            await _client.DeviceRefresh(model);
        }

        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <returns></returns>
        private async Task DeviceModify()
        {
            var model = new DeviceModifyModel
            {
                DeviceId = _deviceId,
                Name = "测试"
            };

            await _client.DeviceModify(model);
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <returns></returns>
        private async Task DeviceDelete()
        {
            await _client.DeviceDelete(_deviceId);
        }

        /// <summary>
        /// 查询设备激活状态
        /// </summary>
        /// <returns></returns>
        private async Task DeviceActivated()
        {
            await _client.DeviceActivated(_deviceId);
        }

        /// <summary>
        /// 查询单个设备信息
        /// </summary>
        /// <returns></returns>
        private async Task DeviceGet()
        {
            await _client.DeviceGet(_deviceId);
        }

        /// <summary>
        /// 批量查询设备信息
        /// </summary>
        /// <returns></returns>
        private async Task DeviceQuery()
        {
            var model = new DeviceInfoQueryModel
            {
                StartTime = DateTime.Now.AddDays(-7)
            };

            await _client.DeviceQuery(model);
        }

        /// <summary>
        /// 查询设备历史数据
        /// </summary>
        /// <returns></returns>
        private async Task DeviceDataHistory()
        {
            var model = new DeviceDataHistoryQueryModel
            {
                DeviceId = _deviceId
            };

            await _client.DeviceDataHistory(model);
        }

        /// <summary>
        /// 订阅平台业务数据
        /// </summary>
        /// <returns></returns>
        private async Task Subscribe()
        {
            var model = new SubscribeModel
            {
                NotifyType = NotifyType.DeviceDataChanged,
                CallbackUrl = "http://api.text.com"
            };

            await _client.Subscribe(model);
        }

        /// <summary>
        /// 查询单个订阅信息
        /// </summary>
        /// <returns></returns>
        private async Task SubscriptionGet()
        {
            var model = new SubscribeModel
            {
                NotifyType = NotifyType.DeviceDataChanged,
                CallbackUrl = "http://api.text.com"
            };

            var result = await _client.Subscribe(model);

            await _client.SubscriptionGet(result.Data.SubscriptionId);
        }

        /// <summary>
        /// 批量查询订阅
        /// </summary>
        /// <returns></returns>
        private async Task<SubscriptionQueryResult> SubscriptionQuery()
        {
            var model = new SubscriptionQueryModel
            {
                NotifyType = NotifyType.DeviceDataChanged
            };

            return (await _client.SubscriptionQuery(model)).Data;
        }

        /// <summary>
        /// 删除单个订阅
        /// </summary>
        /// <returns></returns>
        private async Task SubscriptionDelete()
        {
            var result = await SubscriptionQuery();

            await _client.SubscriptionDelete(result.Subscriptions.LastOrDefault().SubscriptionId);
        }

        /// <summary>
        /// 创建命令
        /// </summary>
        /// <returns></returns>
        private async Task CommandCreate()
        {
            var model = new CommandCreateModel
            {
                DeviceId = _deviceId,
                Command = new CommandBody
                {
                    ServiceId = "DTU",
                    Method = "SETCommand",
                    Paras = new
                    {
                        Value = "1111"
                    }
                }
            };

            await _client.CommandCreate(model);
        }

        /// <summary>
        /// 查询设备命令
        /// </summary>
        /// <returns></returns>
        private async Task CommandQuery()
        {
            await _client.CommandQuery();
        }
    }
}
