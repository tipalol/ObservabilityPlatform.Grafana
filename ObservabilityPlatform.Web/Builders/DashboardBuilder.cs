namespace ObservabilityPlatform.Web.Builders
{
    public class DashboardBuilder
    {
        private string _dashboard;

        public DashboardBuilder(string rawDashboard)
        {
            _dashboard = rawDashboard;
        }

        public DashboardBuilder SetTitle(string title)
        {
            _dashboard = _dashboard.Replace("[dashboard-title]", title);

            return this;
        }

        public DashboardBuilder SetZabbixDatasource(string datasourceName)
        {
            _dashboard = _dashboard.Replace("[zabbix-datasource]", datasourceName);

            return this;
        }

        public DashboardBuilder SetApplicationGroup(string applicationGroup)
        {
            _dashboard = _dashboard.Replace("[application-group]", applicationGroup);

            return this;
        }

        public string Build()
        {
            return _dashboard;
        }
    }
}