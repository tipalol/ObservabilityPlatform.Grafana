using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaClient.Helpers;
using ObservabilityPlatform.GrafanaClient.IntegrationTests.Helpers;
using ObservabilityPlatform.GrafanaClient.Requests;
using ObservabilityPlatform.GrafanaClient.Responses;
using Serilog;

namespace ObservabilityPlatform.GrafanaClient.IntegrationTests
{
    public class Tests
    {
        private IGrafana _grafana;
        private ILogger _logger;
        
        [SetUp]
        public void Setup()
        {
            var (host, login, password) = EnvironmentHelper.GetSecrets();
            
            _grafana = new Grafana.Builder()
                .ConnectTo(host)
                .UseBaseAuthentication(login, password)
                .Build();

            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        
        [Test]
        public async Task CreateDataSource()
        {
            var datasource = new Datasource()
            {
                Name = "Test Datasource",
                Type = "graphite",
                Url = "http://localhost:3000",
                Access = "proxy",
                BasicAuth = false
            };

            var response = await _grafana.CreateDataSource(datasource);
            
            _logger.Debug($"{nameof(CreateDataSource)} " + response);
            Assert.IsNotEmpty(response);
        }
        
        [Test]
        public async Task CreateDataSourceWithBasicAuth()
        {
            var datasource = new Datasource()
            {
                Name = "Test Datasource With Basic Auth",
                Type = "graphite",
                Url = "http://localhost:3000",
                Access = "proxy",
                BasicAuth = true,
                BasicAuthUser = "user_name",
                BasicAuthPassword = "user_password"
            };
            
            _logger.Information(JsonConvert.SerializeObject(datasource));

            var response = await _grafana.CreateDataSourceWithBasicAuth(datasource);
            
            _logger.Debug($"{nameof(CreateDataSourceWithBasicAuth)} " + response);
            Assert.IsNotEmpty(response);
        }

        [Test]
        public async Task CreateDashboard()
        {
            var dashboard = new Dashboard()
            {
                Title = "Rnd Man"
            };

            var creationRequest = new DashboardCreationRequest()
            {
                Dashboard = dashboard
            };
            
            _logger.Information(JsonConvert.SerializeObject(creationRequest));

            var response = await _grafana.CreateDashboard(creationRequest);
            
            _logger.Debug($"{nameof(CreateDashboard)} " + response);
            Assert.IsNotEmpty(response);
        }

        [Test]
        public async Task GetHomeDashboard()
        {
            var response = await _grafana.GetHomeDashboardAsync();

            _logger.Debug($"{nameof(GetHomeDashboard)} " + response);
            Assert.IsNotEmpty(response);
        }
        
        [Test]
        public async Task GetAllDataSources()
        {
            var response = await _grafana.GetAllDataSources();

            _logger.Debug($"{nameof(GetAllDataSources)} " + JsonHelper.Serialize(response));
            Assert.IsNotEmpty(response);
        }
        
        [Test]
        public async Task GetDataSource()
        {
            const uint dataSourceId = 5;
            var response = await _grafana.GetDataSource<GetElasticSourceResponse>(dataSourceId);

            _logger.Debug($"{nameof(GetDataSource)} " + JsonHelper.Serialize(response));
            Assert.IsNotEmpty(JsonHelper.Serialize(response));
        }
        
        [Test]
        public async Task GetDataSourceByName()
        {
            const string dataSourceName = "Hello";
            var response = await _grafana.GetDataSource<GetElasticSourceResponse>(dataSourceName);

            _logger.Debug($"{nameof(GetDataSourceByName)} " + JsonHelper.Serialize(response));
            Assert.IsNotEmpty(JsonHelper.Serialize(response));
        }
        
        [Test]
        public async Task GetDataSourceByUid()
        {
            const string dataSourceUid = "9RkPn04nz";
            var response = await _grafana.GetDataSourceByUid<GetElasticSourceResponse>(dataSourceUid);

            _logger.Debug($"{nameof(GetDataSourceByUid)} " + JsonHelper.Serialize(response));
            Assert.IsNotEmpty(JsonHelper.Serialize(response));
        }
        
        [Test]
        public async Task GetDashboardByUid()
        {
            const string dashboardUid = "DMFpWkVnz";
            var response = await _grafana.GetDashboard(dashboardUid);
            
            _logger.Information($"" +
                                $"Dashboard id is {response.dashboard.id}, " +
                                $"uid is {response.dashboard.uid}, " +
                                $"title is {response.dashboard.title}");
            
            _logger.Information($"{nameof(GetDashboardByUid)} " + response);
            Assert.IsNotNull(response);
        }

        [Ignore("Because")]
        [Test]
        public async Task DeleteDatasource()
        {
            const uint datasourceId = 1;

            var response = await _grafana.DeleteDataSource(datasourceId);
            
            _logger.Debug($"{nameof(DeleteDatasource)} " + response);
            Assert.IsNotEmpty(response);
        }
    }
}