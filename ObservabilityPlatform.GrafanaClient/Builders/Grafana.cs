using System;
using ObservabilityPlatform.GrafanaClient.Security;

// ReSharper disable once CheckNamespace
namespace ObservabilityPlatform.GrafanaClient
{
    public partial class Grafana
    {
        public class Builder
        {
            public string Host { get; private set; }

            private IAuthentication _authentication;

            public Builder ConnectTo(string host)
            {
                ThrowIfNullOrEmpty(nameof(ConnectTo), nameof(host), host);
                
                Host = host;

                return this;
            }

            public Builder UseBaseAuthentication(string login, string password)
            {
                ThrowIfNullOrEmpty(nameof(UseBaseAuthentication), nameof(login), login);
                ThrowIfNullOrEmpty(nameof(UseBaseAuthentication), nameof(password), password);
                
                _authentication = new BaseAuthentication(login, password);

                return this;
            }

            public Builder UseTokenAuthentication(string token)
            {
                ThrowIfNullOrEmpty(nameof(UseTokenAuthentication), nameof(token), token);
                
                _authentication = new TokenAuthentication(token);

                return this;
            }
            
            public IGrafana Build() => new Grafana(Host, _authentication);

            private static void ThrowIfNullOrEmpty(string methodName, string parameter, string nullable)
            {
                if (string.IsNullOrEmpty(nullable))
                    throw new ArgumentNullException(parameter, $"{methodName} argument {parameter}");
            }
        }
    }
}