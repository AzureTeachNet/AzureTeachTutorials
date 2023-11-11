using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace SwaggerClientCredentials
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public async Task<IActionResult> Token()
        {
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            byte[] data = Convert.FromBase64String(authorizationHeader.Split(' ')[1]);
            string decodedString = System.Text.Encoding.UTF8.GetString(data);
            IConfidentialClientApplication app;

            app = ConfidentialClientApplicationBuilder
                    .Create(decodedString.Split(':')[0])
                    .WithClientSecret(decodedString.Split(':')[1])
                    .WithAuthority(new Uri($"{_config.GetValue<string>("AzureAd:Instance")}{_config.GetValue<string>("AzureAd:TenantId")}"))
                    .Build();
            var tokenResult = await app.AcquireTokenForClient(new List<string> { _config.GetValue<string>("AzureAd:DefaultApiScope") }).ExecuteAsync();
            return Ok(new { access_token=tokenResult.AccessToken});
        }
    }
}
