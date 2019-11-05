using System.Net.Http.Headers;

namespace HuaWei.IoT.NorthApi.Sdk.Internal
{
    internal class ContentType
    {
        /// <summary>
        /// application/x-www-form-urlencoded
        /// </summary>
        public static MediaTypeHeaderValue From = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

        /// <summary>
        /// application/json
        /// </summary>
        public static MediaTypeHeaderValue Json = new MediaTypeHeaderValue("application/json");
    }
}
