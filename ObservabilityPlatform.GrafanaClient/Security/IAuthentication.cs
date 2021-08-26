using System.Net.Http;

namespace ObservabilityPlatform.GrafanaClient.Security
{
    internal interface IAuthentication
    {
        public (HttpClient client, string host) AuthenticateClient(HttpClient client, string host);
    }
}