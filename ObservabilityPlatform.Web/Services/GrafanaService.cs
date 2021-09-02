using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Responses;
using ObservabilityPlatform.Web.Helpers;

namespace ObservabilityPlatform.Web.Services
{
    public class GrafanaService : IGrafanaService
    {
        private readonly IGrafana _grafana;

        public GrafanaService()
        {
            //var (host, login, password) = EnvironmentHelper.GetSecrets();

            _grafana = new Grafana.Builder()
                .ConnectTo("185.229.224.209:3000")
                .UseBaseAuthentication("admin", "admin")
                .Build();

            _grafana.GetAllDataSources();
        }

        public async Task<PostDatasourceResult> CreateDatasource(Datasource datasource)
        {
            var response = await _grafana.CreateDataSourceWithBasicAuth(datasource);

            return response;
        }

        public Task<PostDashboardResponse> CreateDashboard(Dashboard dashboard)
        {
            throw new System.NotImplementedException();
        }
    }
}