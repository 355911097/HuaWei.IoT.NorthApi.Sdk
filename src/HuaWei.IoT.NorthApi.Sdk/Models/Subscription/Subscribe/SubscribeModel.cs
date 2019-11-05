using HuaWei.IoT.NorthApi.Sdk.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Subscription.Subscribe
{
    /// <summary>
    /// 订阅平台业务数据
    /// </summary>
    public class SubscribeModel
    {
        /// <summary>
        /// callbackUrl的所有者标识。
        /// <para>OwnerFlag为false时，表示callbackUrl的owner是授权应用。</para>
        /// <para>OwnerFlag为true时，表示callbackUrl的owner为被授权应用。</para>
        /// <para>可选</para>
        /// </summary>
        public bool OwnerFlag { get; set; }

        /// <summary>
        /// 通知类型，应用可以根据通知类型接收物联网平台推送的对应通知消息。
        /// <para>必选</para>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter), true)]
        public NotifyType NotifyType { get; set; }

        /// <summary>
        /// 订阅的回调地址，用于接收对应类型的通知消息。
        /// <para>可使用HTTPS或HTTP回调地址，建议使用HTTPS。</para>
        /// <para>回调地址支持IP地址或域名格式，同时回调地址中必须指定回调地址的端口。例如：https://XXX.XXX.XXX.XXX:443/callbackurltest</para>
        /// <para>必选</para>
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 传输通道，若是MQTT客户端订阅，则取值为MQTT，其他情况为HTTP。
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Channel? Channel { get; set; }
    }
}
