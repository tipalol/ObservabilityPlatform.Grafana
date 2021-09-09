using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Helpers;

namespace ObservabilityPlatform.GrafanaClient.Requests
{
    public class RequestSender : IDisposable
    {
        private readonly HttpClient _client = new();
        private readonly string _baseUri;

        public RequestSender(string host, string token, string tokenType)
        {
            _client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(tokenType, token);

            _baseUri = $"https://{host}/api";
        }

        public async Task<string> Get(string request)
        {
            var response = await _client.GetAsync($"{_baseUri}{request}");

            return await response.Content.ReadAsStringAsync();
        }
        
        public async Task<string> Delete(string request)
        {
            var response = await _client.DeleteAsync($"{_baseUri}{request}");

            return JsonHelper.Serialize(response);
        }
        
        public async Task<string> Post(string request, string content)
        {
            var webContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_baseUri}{request}", webContent);

            return JsonHelper.Serialize(response.Content.ReadAsStringAsync());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _client?.Dispose();
        }
    }
}