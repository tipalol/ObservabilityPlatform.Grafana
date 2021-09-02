using System.Collections.Generic;
using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Responses;
using ObservabilityPlatform.GrafanaClient.Requests;

namespace ObservabilityPlatform.GrafanaClient
{
    public interface IGrafana
    {
        public Task<T> GetDataSource<T>(uint id) where T : GetDatasourceResponse, new();
        public Task<T> GetDataSource<T>(string name) where T : GetDatasourceResponse, new();
        public Task<T> GetDataSourceByUid<T>(string uid) where T : GetDatasourceResponse, new();
        public Task<List<Datasource>> GetAllDataSources();
        public Task<string> CreateDataSource(Datasource datasource);
        public Task<PostDatasourceResult> CreateDataSourceWithBasicAuth(Datasource datasource);
        public Task<string> DeleteDataSource(uint id);
        public Task<string> DeleteDataSource(string name);
        public Task<GetDashboardResponse> GetDashboard(string uid);
        public Task<string> GetHomeDashboardAsync();
        public Task<string> CreateDashboard(DashboardCreationRequest request);
        public Task<string> CreateDashboardWithoutValidation(string request);
    }
}