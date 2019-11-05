using HuaWei.IoT.NorthApi.Sdk.Enums;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Delete
{
    /// <summary>
    /// 批量删除订阅模型
    /// </summary>
    public class SubscriptionDeleteModel
    {
        /// <summary>
        /// 通知类型
        /// <para>可选</para>
        /// </summary>
        public NotifyType? NotifyType { get; set; }

        /// <summary>
        /// 订阅回调的URL地址。
        /// <para>可选</para>
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 传输通道。
        /// <para>可选</para>
        /// </summary>
        public Channel? Channel { get; set; }
    }
}
