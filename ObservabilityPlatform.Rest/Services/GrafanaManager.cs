using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ObservabilityPlatform.GrafanaClient;
using ObservabilityPlatform.Rest.Helper;

namespace ObservabilityPlatform.Rest.Services
{
    internal class GrafanaManager : IGrafanaManager
    {
        private readonly IGrafana _grafana;
        private readonly string _dashboardTemplate;

        public GrafanaManager(IConfiguration configuration)
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

            var templatePath = configuration["DashboardTemplatePath"];
            _dashboardTemplate = File.ReadAllText(templatePath);
        }
        
        
        public async Task<HttpStatusCode> CreateDashboard(string dashboardTitle, string applicationGroup)
        {
            var dashboard = new RawDashboardBuilder(_dashboardTemplate)
                .SetTitle(dashboardTitle)
                .SetApplicationGroup(applicationGroup)
                .Build();

            try
            {
                var response = await _grafana.CreateDashboardWithoutValidation(dashboard);
            }
            catch (Exception e)
            {
                return HttpStatusCode.BadRequest;
            }
            
            return HttpStatusCode.OK;
        }
    }
}