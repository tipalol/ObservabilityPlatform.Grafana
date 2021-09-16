using System.Net;
using System.Threading.Tasks;

namespace ObservabilityPlatform.Rest.Services
{
    internal class ProductRegisterService : IProductRegisterService
    {
        private readonly IGrafanaManager _grafana;

        public ProductRegisterService(IGrafanaManager grafanaManager)
        {
            _grafana = grafanaManager;
        }
        
        public async Task<HttpStatusCode> RegisterProduct(string applicationGroup)
        {
            var status = await _grafana.CreateDashboard(
                applicationGroup.Replace("Приложение/", string.Empty), 
                applicationGroup);

            return status;
        }
    }
}