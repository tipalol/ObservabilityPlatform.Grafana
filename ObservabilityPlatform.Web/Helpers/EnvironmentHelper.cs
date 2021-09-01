using System;

namespace ObservabilityPlatform.Web.Helpers
{
    public static class EnvironmentHelper
    {
        public static (string host, string login, string password) GetSecrets()
        {
            var host = Environment.GetEnvironmentVariable("grafana_host");
            var login = Environment.GetEnvironmentVariable("grafana_login");
            var password = Environment.GetEnvironmentVariable("grafana_password");

            ThrowIfNullOrEmpty(nameof(GetSecrets), nameof(host), host);
            ThrowIfNullOrEmpty(nameof(GetSecrets), nameof(login), login);
            ThrowIfNullOrEmpty(nameof(GetSecrets), nameof(password), password);

            return (host, login, password);
        }
        
        private static void ThrowIfNullOrEmpty(string methodName, string parameter, string nullable)
        {
            if (string.IsNullOrEmpty(nullable))
                throw new ArgumentNullException(parameter, $"{methodName} argument {parameter}");
        }
    }
}