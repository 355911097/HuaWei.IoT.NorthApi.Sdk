using System.Collections.Generic;
using HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Get;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Query
{
    /// <summary>
    /// 批量查询订阅结果
    /// </summary>
    public class SubscriptionQueryResult : NorthApiQueryResult
    {
        /// <summary>
        /// 订阅信息列表。
        /// </summary>
        public List<SubscriptionModel> Subscriptions { get; set; }
    }
}
