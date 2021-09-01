using System.Net.Http;
using ObservabilityPlatform.GrafanaClient.Requests;

namespace ObservabilityPlatform.GrafanaClient.Security
{
    internal interface IAuthentication
    {
        public (RequestSender client, string host) AuthenticateClientV2(string host);
    }
}