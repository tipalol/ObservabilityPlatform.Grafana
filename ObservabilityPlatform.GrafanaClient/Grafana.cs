using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Requests;
using ObservabilityPlatform.GrafanaClient.Security;
using Newtonsoft.Json;
using ObservabilityPlatform.GrafanaClient.Helpers;
using ObservabilityPlatform.GrafanaClient.Responses;

namespace ObservabilityPlatform.GrafanaClient
{
    public partial class Grafana : IGrafana
    {
        private readonly RequestSender _sender;

        private Grafana(string host, IAuthentication authentication)
        {
            var (sender, _) = authentication.AuthenticateClientV2(host);
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

            return response;
        }

        public async Task<string> CreateDashboardWithoutValidation(string request)
        {
            var response = await _sender.Post($"/dashboards/db", request);

            return response;
        }

        public async Task<List<Datasource>> GetAllDataSources()
        {
            var response = await _sender.Get($"/datasources");
            var datasources = JsonHelper.Deserialize<List<Datasource>>(response);

            return datasources;
        }

        public async Task<T> GetDataSource<T>(uint id) where T : GetDatasourceResponse, new()
        {
            var response = await _sender.Get($"/datasources/{id}");

            var datasource = JsonHelper.Deserialize<T>(response);
            
            return datasource;
        }

        public async Task<T> GetDataSource<T>(string name) where T : GetDatasourceResponse, new()
        {
            var response = await _sender.Get($"/datasources/name/{name}");

            var datasource = JsonHelper.Deserialize<T>(response);

            return datasource;
        }

        public async Task<T> GetDataSourceByUid<T>(string uid) where T : GetDatasourceResponse, new()
        {
            var response = await _sender.Get($"/datasources/uid/{uid}");

            var datasource = JsonHelper.Deserialize<T>(response);

            return datasource;
        }

        public async Task<string> CreateDataSource(Datasource datasource)
        {
            var json = JsonHelper.Serialize(datasource);
            var response = await _sender.Post($"/datasources", json);

            return JsonHelper.Serialize(response);
        }

        public async Task<PostDatasourceResult> CreateDataSourceWithBasicAuth(Datasource datasource)
        {
            var json = JsonHelper.Serialize(datasource);
            var response = await _sender.Post($"/datasources", json);
            
            await File.WriteAllTextAsync("info.txt", response);
            var postSourceResponse = JsonHelper.Deserialize<PostDatasourceResponse>(response);
            var result = JsonHelper.Deserialize<PostDatasourceResult>(postSourceResponse.Result);

            return result;
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