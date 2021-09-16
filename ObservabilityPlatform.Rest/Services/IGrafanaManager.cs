using System.Net;
using System.Threading.Tasks;

namespace ObservabilityPlatform.Rest.Services
{
    public interface IGrafanaManager
    {
        public Task<HttpStatusCode> CreateDashboard(string dashboardTitle, string applicationGroup);
    }
}