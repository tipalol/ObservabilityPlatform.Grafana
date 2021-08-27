using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Requests;
using ObservabilityPlatform.GrafanaClient.Security;
using Newtonsoft.Json;
using ObservabilityPlatform.GrafanaClient.Helpers;

namespace ObservabilityPlatform.GrafanaClient
{
    public partial class Grafana : IGrafana
    {
        private readonly string _host;
        private readonly HttpClient _client;

        private string Api => $"http://{_host}/api/";

        private Grafana(string host, IAuthentication authentication)
        {
            _client = new HttpClient();
            var (client, authedHost) = authentication.AuthenticateClient(_client, host);
            _host = authedHost;
            _client = client;
        }

        public async Task<string> GetHomeDashboardAsync()
        {
            Console.WriteLine(_client.BaseAddress! + "/dashboards/home");
            var response = await _client.GetStringAsync($"/dashboards/home");

            return response;
        }

        public async Task<string> CreateDashboard(DashboardCreationRequest request)
        {
            var json = JsonHelper.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"/dashboards/db/", content);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> GetAllDataSources()
        {
            var response = await _client.GetStringAsync($"/datasources");

            return response;
        }

        public async Task<string> GetDataSource(uint id)
        {
            var response = await _client.GetStringAsync($"/datasources/{id}");

            return response;
        }

        public async Task<string> GetDataSource(string name)
        {
            var response = await _client.GetStringAsync($"/datasources/name/{name}");

            return response;
        }

        public async Task<string> GetDataSourceByUid(string uid)
        {
            var response = await _client.GetStringAsync($"/datasources/uid/{uid}");

            return response;
        }

        public async Task<string> CreateDataSource(Datasource datasource)
        {
            var json = JsonHelper.Serialize(datasource);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"/datasources/", content);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> CreateDataSourceWithBasicAuth(BasicDatasource datasource)
        {
            var json = JsonHelper.Serialize(datasource);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"/datasources/", content);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> DeleteDataSource(uint id)
        {
            var response = await _client.DeleteAsync($"/datasources/{id}");

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> DeleteDataSource(string name)
        {
            var response = await _client.DeleteAsync($"/datasources/name/{name}");

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> GetDashboard(string uid)
        {
            var response = await _client.GetStringAsync($"/dashboards/uid/{uid}");

            return response;
        }

        private async Task<string> Get(string relativeUri)
        {
            var response = await _client.GetStringAsync(relativeUri);

            return response;
        }

        /*private async Task<string> Post(string relativeUri, string content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);

            request.Content = new StringContent(content);
            
            var response = await _client.PostAsync(relativeUri, content);

            return response;
        }*/
    }
}