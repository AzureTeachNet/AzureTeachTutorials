using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAngularAdDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:scopes")]
    public class ReportController : ControllerBase
    {
        [Authorize(Roles ="Manager")]
        [HttpGet("[action]")]
        public IActionResult GetReport()
        {
            return File(System.IO.File.ReadAllBytes(@"D:\Tutorials\SampleReport.pdf"), "application/pdf");
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult GetReportStatus()
        {
            return Ok(new { Status = @"Report Generated at - " + DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") });
        }
        //[AllowAnonymous]
        //[HttpGet("[action]")]
        //public IActionResult Anonymous()
        //{
        //    return Ok(new { Status = @"Report Generated at - " + DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") });
        //}
    }
}
