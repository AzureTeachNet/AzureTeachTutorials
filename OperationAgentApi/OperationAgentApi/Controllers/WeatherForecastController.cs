//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Microsoft.Identity.Web.Resource;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Identity.Web;

//namespace OperationAgentApi.Controllers
//{
//    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
//    [Authorize]
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private readonly IDownstreamWebApi _downstreamWebApi;
//        private static readonly string[] Summaries = new[]
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//        private readonly ILogger<WeatherForecastController> _logger;

//        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
//        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

//        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDownstreamWebApi downstreamWebApi)
//        {
//            _logger = logger;
//            _downstreamWebApi = downstreamWebApi;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<WeatherForecast>> Get()
//        {
//            using var response = await _downstreamWebApi.CallWebApiForUserAsync("DownstreamApi").ConfigureAwait(false);
//            if (response.StatusCode == System.Net.HttpStatusCode.OK)
//            {
//                var apiResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
//                // Do something
//            }
//            else
//            {
//                var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
//                //throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}: {error}");
//            };
//            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

//            var rng = new Random();
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            {
//                Date = DateTime.Now.AddDays(index),
//                TemperatureC = rng.Next(-20, 55),
//                Summary = Summaries[rng.Next(Summaries.Length)]
//            })
//            .ToArray();
//        }
//    }
//}
