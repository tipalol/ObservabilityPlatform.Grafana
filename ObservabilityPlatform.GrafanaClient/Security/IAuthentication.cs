using System.Net.Http;
using ObservabilityPlatform.GrafanaClient.Requests;

namespace ObservabilityPlatform.GrafanaClient.Security
{
    internal interface IAuthentication
    {
        public (HttpClient client, string host) AuthenticateClient(HttpClient client, string host);
        public (RequestSender client, string host) AuthenticateClientV2(RequestSender client, string host);
    }
}