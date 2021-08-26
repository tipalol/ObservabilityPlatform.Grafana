using System.Collections.Generic;
using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Entities;

namespace ObservabilityPlatform.GrafanaClient
{
    public interface IGrafana
    {
        public Task<string> GetHomeDashboardAsync();
        public Task<string> GetAllDataSources();
        public Task<string> GetDataSource(uint id);
        public Task<string> GetDataSource(string name);
        public Task<string> GetDataSourceByUid(string uid);
        public Task<string> CreateDataSource(Datasource datasource);
        public Task<string> CreateDataSourceWithBasicAuth(BasicDatasource datasource);
        public Task<string> GetDashboard(string uid);
    }
}