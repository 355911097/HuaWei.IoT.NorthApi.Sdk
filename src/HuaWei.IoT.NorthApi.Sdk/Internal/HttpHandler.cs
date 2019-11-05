using System.IO;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HuaWei.IoT.NorthApi.Sdk.Internal
{
    /// <summary>
    /// 请求处理器
    /// </summary>
    internal class HttpHandler
    {
        private readonly ILogger _logger;
        private readonly NorthApiOptions _options;
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public HttpHandler(ILoggerFactory loggerFactory, NorthApiOptions options)
        {
            _logger = loggerFactory?.CreateLogger(typeof(HttpHandler));
            _options = options;

            Verify();

            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12,
                ServerCertificateCustomValidationCallback = (x, y, z, m) => true,
            };
            handler.ClientCertificates.Add(new X509Certificate2(_options.Cert.Path, _options.Cert.Password));
            _httpClient = new HttpClient(handler);

        }

        /// <summary>
        /// 验证
        /// </summary>
        private void Verify()
        {
            Check.NotNull(_options.AppId, nameof(_options.AppId), "AppId未设置");
            Check.NotNull(_options.Secret, nameof(_options.Secret), "Secret未设置");
            Check.NotNull(_options.BaseUrl, nameof(_options.BaseUrl), "BaseUrl未设置");
            Check.NotNull(_options.Cert, nameof(_options.Cert), "证书未设置");
            Check.NotNull(_options.Cert.Path, nameof(_options.Cert.Path), "证书路径未设置");

            _options.Cert.Path = Path.GetFullPath(_options.Cert.Path);

            if (!File.Exists(_options.Cert.Path))
            {
                throw new FileNotFoundException("证书不存在");
            }
        }

        /// <summary>
        /// 刷新认证信息
        /// </summary>
        /// <param name="token"></param>
        public void RefreshAuth(NorthApiToken token)
        {
            _httpClient.DefaultRequestHeaders.Remove("app_key");
            _httpClient.DefaultRequestHeaders.Remove("Authorization");

            _httpClient.DefaultRequestHeaders.Add("app_key", _options.AppId);
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.AccessToken);
        }

        /// <summary>
        /// Post Form
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult> PostForm(string url, string data)
        {
            var content = new StringContent(data);
            content.Headers.ContentType = ContentType.From;

            var httpResponseMessage = await _httpClient.PostAsync(url, content);
            var result = new HttpResponseResult
            {
                StatusCode = httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync()
            };

            _logger?.LogDebug($"PostForm：url:{url}, data:{data}, statusCode:{result.StatusCode}, content:{result.Content}");

            return result;
        }

        /// <summary>
        /// Post Json
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult> PostJson<T>(string url, T obj)
        {
            var data = JsonConvert.SerializeObject(obj, _jsonSerializerSettings);

            var content = new StringContent(data);
            content.Headers.ContentType = ContentType.Json;

            var httpResponseMessage = await _httpClient.PostAsync(url, content);
            var result = new HttpResponseResult
            {
                StatusCode = httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync()
            };
            
            _logger?.LogDebug($"PostJson：url:{url}, data:{data}, statusCode:{result.StatusCode}, content:{result.Content}");
            
            return result;
        }

        /// <summary>
        /// Put Json
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult> PutJson<T>(string url, T obj)
        {
            var data = JsonConvert.SerializeObject(obj, _jsonSerializerSettings);

            var content = new StringContent(data);
            content.Headers.ContentType = ContentType.Json;

            var httpResponseMessage = await _httpClient.PutAsync(url, content);
            var result = new HttpResponseResult
            {
                StatusCode = httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync()
            };

            _logger?.LogDebug($"PutJson：url:{url}, data:{data}, statusCode:{result.StatusCode}, content:{result.Content}");

            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult> Delete(string url)
        {
            var httpResponseMessage = await _httpClient.DeleteAsync(url);
            var result = new HttpResponseResult
            {
                StatusCode = httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync()
            };

            _logger?.LogDebug($"Delete：url:{url}, statusCode:{result.StatusCode}, content:{result.Content}");

            return result;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<HttpResponseResult> Get(string url)
        {
            var httpResponseMessage = await _httpClient.GetAsync(url);
            var result = new HttpResponseResult
            {
                StatusCode = httpResponseMessage.StatusCode,
                Content = await httpResponseMessage.Content.ReadAsStringAsync()
            };

            _logger?.LogDebug($"Get：url:{url}, statusCode:{result.StatusCode}, content:{result.Content}");

            return result;
        }

    }
}
