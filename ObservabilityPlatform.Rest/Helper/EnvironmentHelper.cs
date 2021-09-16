using System;

namespace ObservabilityPlatform.Rest.Helper
{
    internal static class EnvironmentHelper
    {
        public static (string host, string login, string password) GetBasicSecrets()
        {
            var host = Environment.GetEnvironmentVariable("grafana_host");
            var login = Environment.GetEnvironmentVariable("grafana_login");
            var password = Environment.GetEnvironmentVariable("grafana_password");

            ThrowIfNullOrEmpty(nameof(GetBasicSecrets), nameof(host), host);
            ThrowIfNullOrEmpty(nameof(GetBasicSecrets), nameof(login), login);
            ThrowIfNullOrEmpty(nameof(GetBasicSecrets), nameof(password), password);

            return (host, login, password);
        }

        public static (string host, string token) GetBearerSecrets()
        {
            var host = Environment.GetEnvironmentVariable("grafana_host");
            var token = Environment.GetEnvironmentVariable("grafana_token");
            
            ThrowIfNullOrEmpty(nameof(GetBearerSecrets), nameof(host), host);
            ThrowIfNullOrEmpty(nameof(GetBearerSecrets), nameof(token), token);

            return (host, token);
        }
        
        private static void ThrowIfNullOrEmpty(string methodName, string parameter, string nullable)
        {
            if (string.IsNullOrEmpty(nullable))
                throw new ArgumentNullException(parameter, $"{methodName} argument {parameter}");
        }
    }
}