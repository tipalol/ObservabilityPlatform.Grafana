using System.Threading.Tasks;

namespace ObservabilityPlatform.Web.Services
{
    public interface IRegisterClientService
    {
        public Task<string> RegisterNewProduct(string productGroup);
    }
}