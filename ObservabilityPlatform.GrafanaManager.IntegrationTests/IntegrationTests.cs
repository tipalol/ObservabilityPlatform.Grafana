using System.Threading.Tasks;
using NUnit.Framework;
using ObservabilityPlatform.GrafanaClient;
using ObservabilityPlatform.GrafanaClient.Entities;
using ObservabilityPlatform.GrafanaManager.IntegrationTests.Helpers;
using Serilog;

namespace ObservabilityPlatform.GrafanaManager.IntegrationTests
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

            _logger.Debug($"{nameof(GetHomeDashboard)} " + response);
            Assert.IsNotEmpty(response);
        }
        
        [Test]
        public async Task GetDataSource()
        {
            const uint dataSourceId = 1;
            var response = await _grafana.GetDataSource(dataSourceId);

            _logger.Debug($"{nameof(GetHomeDashboard)} " + response);
            Assert.IsNotEmpty(response);
        }
        
        [Test]
        public async Task GetDataSourceByName()
        {
            const string dataSourceName = "Jaeger";
            var response = await _grafana.GetDataSource(dataSourceName);

            _logger.Debug($"{nameof(GetHomeDashboard)} " + response);
            Assert.IsNotEmpty(response);
        }
        
        [Test]
        public async Task GetDataSourceByUid()
        {
            const string dataSourceUid = "2eVBDWVnz";
            var response = await _grafana.GetDataSourceByUid(dataSourceUid);

            _logger.Debug($"{nameof(GetHomeDashboard)} " + response);
            Assert.IsNotEmpty(response);
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
            
            _logger.Debug($"{nameof(GetHomeDashboard)} " + response);
            Assert.IsNotEmpty(response);
        }
        
        [Test]
        public async Task CreateDataSourceWithBasicAuth()
        {
            var datasource = new BasicDatasource()
            {
                Name = "Test Datasource",
                Type = "graphite",
                Url = "http://localhost:3000",
                Access = "proxy",
                BasicAuth = true,
                BasicAuthUser = "user_name",
                SecureJsonData = new SecureJsonData()
                {
                    BasicAuthPassword = "user_password"
                }
            };

            var response = await _grafana.CreateDataSource(datasource);
            
            _logger.Debug($"{nameof(GetHomeDashboard)} " + response);
            Assert.IsNotEmpty(response);
        }
        
        [Test]
        public async Task GetDashboardByUid()
        {
            const string dashboardUid = "DMFpWkVnz";
            var response = await _grafana.GetDashboard(dashboardUid);

            _logger.Debug($"{nameof(GetHomeDashboard)} " + response);
            Assert.IsNotEmpty(response);
        }
    }
}