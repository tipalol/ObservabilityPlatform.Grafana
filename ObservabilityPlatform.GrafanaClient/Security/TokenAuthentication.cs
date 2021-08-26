using System.Net.Http;
using System.Net.Http.Headers;

namespace ObservabilityPlatform.GrafanaClient.Security
{
    internal class TokenAuthentication : IAuthentication
    {
        private const string AuthenticationBodyPrefix = "Bearer ";

        private readonly string _token;

        public TokenAuthentication(string token)
        {
            _token = token;
        }

        public (HttpClient client, string host) AuthenticateClient(HttpClient client, string host)
        {
            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(AuthenticationBodyPrefix, _token);

            return (client, host);
        }
    }
}