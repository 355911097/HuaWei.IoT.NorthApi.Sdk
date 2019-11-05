using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Query
{
    /// <summary>
    /// 批量查询订阅模型
    /// </summary>
    public class SubscriptionQueryModel : NorthApiQueryPaging
    {
        /// <summary>
        /// 通知类型
        /// <para>可选</para>
        /// </summary>
        public NotifyType? NotifyType { get; set; }
    }
}
