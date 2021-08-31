using System.Collections.Generic;
using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Reponses;
using ObservabilityPlatform.GrafanaClient.Requests;
using ObservabilityPlatform.GrafanaClient.Responses;
using Datasource = ObservabilityPlatform.GrafanaClient.Responses.Datasource;

namespace ObservabilityPlatform.GrafanaClient
{
    public interface IGrafana
    {
        public Task<string> GetDataSource(uint id);
        public Task<string> GetDataSource<T>(string name) where T : GetDatasourceResponse, new();
        public Task<string> GetDataSourceByUid(string uid);
        public Task<string> GetAllDataSources();
        public Task<string> CreateDataSource(Datasource datasource);
        public Task<string> CreateDataSourceWithBasicAuth(BasicDatasource datasource);
        public Task<string> DeleteDataSource(uint id);
        public Task<string> DeleteDataSource(string name);
        public Task<GetDashboardResponse> GetDashboard(string uid);
        public Task<string> GetHomeDashboardAsync();
        public Task<string> CreateDashboard(DashboardCreationRequest request);
    }
}