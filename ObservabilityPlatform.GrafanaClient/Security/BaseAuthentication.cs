using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ObservabilityPlatform.GrafanaClient.Requests;

namespace ObservabilityPlatform.GrafanaClient.Security
{
    internal class BaseAuthentication : IAuthentication
    {
        private readonly string _login;
        private readonly string _password;

        public BaseAuthentication(string login, string password)
        {
            _login = login;
            _password = password;
        }
        
        public (HttpClient client, string host) AuthenticateClient(HttpClient client, string host)
        {
            var token = $"{_login}:{_password}";
            var tokenBytes = Encoding.ASCII.GetBytes(token);
            var tokenBase64 = Convert.ToBase64String(tokenBytes);
            
            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic", tokenBase64);
            
            /*client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));*/

            client.BaseAddress = new Uri($"http://{host}/api");
            
            return (client, host);
        }

        public (RequestSender client, string host) AuthenticateClientV2(RequestSender client, string host)
        {
            var token = $"{_login}:{_password}";

            client = new RequestSender(host, token, "Basic");

            return (client, host);
        }
    }
}