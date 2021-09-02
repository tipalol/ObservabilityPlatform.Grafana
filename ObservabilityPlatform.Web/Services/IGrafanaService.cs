using System.Collections.Generic;
using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Responses;

namespace ObservabilityPlatform.Web.Services
{
    public interface IGrafanaService
    {
        public Task<PostDatasourceResult> CreateDatasource(Datasource datasource);
        public Task<string> CreateDashboardWithoutValidation(string dashboard);
        public Task<List<Datasource>> GetAllDatasources();
        public Task<GetDashboardResponse> GetDashboard(string uid);
    }
}