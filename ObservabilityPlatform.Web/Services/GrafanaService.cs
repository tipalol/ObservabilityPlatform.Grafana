using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ObservabilityPlatform.GrafanaClient;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Responses;
using ObservabilityPlatform.Web.Helpers;

namespace ObservabilityPlatform.Web.Services
{
    public class GrafanaService : IGrafanaService
    {
        private readonly IGrafana _grafana;

        public GrafanaService(IConfiguration configuration)
        {
            if (configuration["UseTokenAuthentication"] == "true")
            {
                var (host, token) = EnvironmentHelper.GetBearerSecrets();
                
                _grafana = new Grafana.Builder()
                    .ConnectTo(host)
                    .UseTokenAuthentication(token)
                    .Build();
            }
            else
            {
                var (host, login, password) = EnvironmentHelper.GetBasicSecrets();

                _grafana = new Grafana.Builder()
                    .ConnectTo(host)
                    .UseBaseAuthentication(login, password)
                    .Build();
            }
        }

        public async Task<PostDatasourceResult> CreateDatasource(Datasource datasource)
        {
            var response = await _grafana.CreateDataSourceWithBasicAuth(datasource);

            return response;
        }

        public async Task<string> CreateDashboardWithoutValidation(string dashboard)
        {
            var response = await _grafana.CreateDashboardWithoutValidation(dashboard);

            return response;
        }

        public async Task<List<Datasource>> GetAllDatasources()
        {
            var datasources = await _grafana.GetAllDataSources();

            return datasources;
        }

        public async Task<GetDashboardResponse> GetDashboard(string uid)
        {
            var response = await _grafana.GetDashboard(uid);

            return response;
        }
    }
}