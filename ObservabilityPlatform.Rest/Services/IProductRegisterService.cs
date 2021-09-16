using System.Net;
using System.Threading.Tasks;

namespace ObservabilityPlatform.Rest.Services
{
    public interface IProductRegisterService
    {
        public Task<HttpStatusCode> RegisterProduct(string applicationGroup);
    }
}