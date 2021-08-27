using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Requests;
using ObservabilityPlatform.GrafanaClient.Security;
using Newtonsoft.Json;
using ObservabilityPlatform.GrafanaClient.Helpers;
using ObservabilityPlatform.GrafanaClient.Reponses;

namespace ObservabilityPlatform.GrafanaClient
{
    public partial class Grafana : IGrafana
    {
        private readonly RequestSender _sender;

        private Grafana(string host, IAuthentication authentication)
        {
            var (sender, _) = authentication.AuthenticateClientV2(_sender, host);
            _sender = sender;
        }

        public async Task<string> GetHomeDashboardAsync()
        {
            var response = await _sender.Get($"/dashboards/home");

            return response;
        }

        public async Task<string> CreateDashboard(DashboardCreationRequest request)
        {
            var json = JsonHelper.Serialize(request);
            var response = await _sender.Post($"/dashboards/db", json);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> GetAllDataSources()
        {
            var response = await _sender.Get($"/datasources");

            return response;
        }

        public async Task<string> GetDataSource(uint id)
        {
            var response = await _sender.Get($"/datasources/{id}");
            
            return response;
        }

        public async Task<string> GetDataSource(string name)
        {
            var response = await _sender.Get($"/datasources/name/{name}");

            return response;
        }

        public async Task<string> GetDataSourceByUid(string uid)
        {
            var response = await _sender.Get($"/datasources/uid/{uid}");

            return response;
        }

        public async Task<string> CreateDataSource(Datasource datasource)
        {
            var json = JsonHelper.Serialize(datasource);
            var response = await _sender.Post($"/datasources", json);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> CreateDataSourceWithBasicAuth(BasicDatasource datasource)
        {
            var json = JsonHelper.Serialize(datasource);
            var response = await _sender.Post($"/datasources", json);

            return JsonHelper.Serialize(response);
        }

        public async Task<string> DeleteDataSource(uint id)
        {
            var response = await _sender.Delete($"/datasources/{id}");

            return JsonConvert.SerializeObject(response);
        }

        public async Task<string> DeleteDataSource(string name)
        {
            var response = await _sender.Delete($"/datasources/name/{name}");

            return JsonConvert.SerializeObject(response);
        }

        public async Task<GetDashboardResponse> GetDashboard(string uid)
        {
            var response = await _sender.Get($"/dashboards/uid/{uid}");

            var dashboard = JsonHelper.Deserialize<GetDashboardResponse>(response);
            
            

            return dashboard;
        }
    }
}