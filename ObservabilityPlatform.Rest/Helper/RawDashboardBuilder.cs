namespace ObservabilityPlatform.Rest.Helper
{
    internal class RawDashboardBuilder
    {
        private string _dashboard;

        public RawDashboardBuilder(string rawDashboard)
        {
            _dashboard = rawDashboard;
        }

        public RawDashboardBuilder SetTitle(string title)
        {
            _dashboard = _dashboard.Replace("[dashboard-title]", title);

            return this;
        }

        public RawDashboardBuilder SetApplicationGroup(string applicationGroup)
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