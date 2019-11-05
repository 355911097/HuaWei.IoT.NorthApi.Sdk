using System.Collections.Generic;
using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Subscribe
{
    /// <summary>
    /// 订阅平台业务数据
    /// </summary>
    public class SubscribeResult
    {
        /// <summary>
        /// 订阅ID，用于唯一标识一个订阅，在创建订阅时由物联网平台分配获得。
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// 通知的类型。
        /// </summary>
        public NotifyType NotifyType { get; set; }

        /// <summary>
        /// 订阅的回调地址。
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// MQTT客户端ID，只有MQTT订阅时该字段有返回值。
        /// </summary>
        public List<string> ClientIds { get; set; }
    }
}
