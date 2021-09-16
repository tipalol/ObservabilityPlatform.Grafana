using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ObservabilityPlatform.Rest.Services;

namespace ObservabilityPlatform.Rest.Controllers
{
    [ApiController]
    [Route("monitoring/api")]
    public class ProductRegisterController
    {
        private readonly ILogger<ProductRegisterController> _logger;
        private readonly IProductRegisterService _productRegisterService;

        public ProductRegisterController(
            ILogger<ProductRegisterController> logger,
            IProductRegisterService productRegisterService)
        {
            _logger = logger;
            _productRegisterService = productRegisterService;
        }
        
        [HttpPost("applications")]
        public async Task<HttpStatusCode> RegisterProduct(string applicationGroup)
        {
            if (string.IsNullOrEmpty(applicationGroup))
            {
                _logger.LogError("Got null or empty productGroup parameter", applicationGroup);
                return HttpStatusCode.BadRequest;
            }
            
            _logger.LogInformation($"Got register {applicationGroup} request", applicationGroup);

            var status = await _productRegisterService.RegisterProduct(applicationGroup);

            if (status != HttpStatusCode.OK)
                _logger.LogError($"Status of registering product was not OK but {status}", status);

            return status;
        }
    }
}