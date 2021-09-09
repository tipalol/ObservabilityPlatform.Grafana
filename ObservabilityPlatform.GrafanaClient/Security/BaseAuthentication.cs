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

        public (RequestSender client, string host) AuthenticateClientV2(string host)
        {
            var token = $"{_login}:{_password}";
            
            var tokenBytes = Encoding.ASCII.GetBytes(token);
            var tokenBase64 = Convert.ToBase64String(tokenBytes);

            var client = new RequestSender(host, tokenBase64, "Basic");

            return (client, host);
        }
    }
}