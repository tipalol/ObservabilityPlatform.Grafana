using System.Threading.Tasks;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Responses;

namespace ObservabilityPlatform.Web.Services
{
    public interface IGrafanaService
    {
        public Task<PostDatasourceResponse> CreateDatasource(Datasource datasource);
        public Task<PostDashboardResponse> CreateDashboard(Dashboard dashboard);
    }
}