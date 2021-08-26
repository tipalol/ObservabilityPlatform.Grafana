using System.Net.Http;
using System.Net.Http.Json;
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

        private string Api => $"http://{_host}/api";

        private Grafana(string host, IAuthentication authentication)
        {
            _client = new HttpClient();
            var (client, authedHost) = authentication.AuthenticateClient(_client, host);
            _host = authedHost;
            _client = client;
        }

        public async Task<string> GetHomeDashboardAsync()
        {
            var response = await _client.GetStringAsync($"{Api}/dashboards/home");

            return response;
        }

        public async Task<string> CreateDashboard(DashboardCreationRequest request)
        {
            var json = JsonHelper.Serialize(request);
            var content = new StringContent(json);
            var response = await _client.PostAsync($"{Api}/dashboards/db/", content);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> GetAllDataSources()
        {
            var response = await _client.GetStringAsync($"{Api}/datasources");

            return response;
        }

        public async Task<string> GetDataSource(uint id)
        {
            var response = await _client.GetStringAsync($"{Api}/datasources/{id}");

            return response;
        }

        public async Task<string> GetDataSource(string name)
        {
            var response = await _client.GetStringAsync($"{Api}/datasources/name/{name}");

            return response;
        }

        public async Task<string> GetDataSourceByUid(string uid)
        {
            var response = await _client.GetStringAsync($"{Api}/datasources/uid/{uid}");

            return response;
        }

        public async Task<string> CreateDataSource(Datasource datasource)
        {
            var json = JsonHelper.Serialize(datasource);
            var content = new StringContent(json);
            var response = await _client.PostAsync($"{Api}/datasources/", content);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> CreateDataSourceWithBasicAuth(BasicDatasource datasource)
        {
            var json = JsonHelper.Serialize(datasource);
            var content = new StringContent(json);
            var response = await _client.PostAsync($"{Api}/datasources/", content);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> DeleteDataSource(uint id)
        {
            var response = await _client.DeleteAsync($"{Api}/datasources/{id}");

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> DeleteDataSource(string name)
        {
            var response = await _client.DeleteAsync($"{Api}/datasources/name/{name}");

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> GetDashboard(string uid)
        {
            var response = await _client.GetStringAsync($"{Api}/dashboards/uid/{uid}");

            return response;
        }
    }
}