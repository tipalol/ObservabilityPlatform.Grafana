using ObservabilityPlatform.GrafanaClient.Requests;

namespace ObservabilityPlatform.GrafanaClient.Security
{
    internal class TokenAuthentication : IAuthentication
    {
        private const string AuthenticationBodyPrefix = "Bearer";

        private readonly string _token;

        public TokenAuthentication(string token)
        {
            _token = token;
        }

        public (RequestSender client, string host) AuthenticateClientV2(string host)
        {
            var client = new RequestSender(host, _token, AuthenticationBodyPrefix);

            return (client, host);
        }
    }
}