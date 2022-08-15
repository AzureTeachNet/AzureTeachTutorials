using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Collections.Generic;
using System.Linq;

namespace MembersInfoApi.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        static readonly string[] scopeRequiredByApi = new string[] { "MembersApi.All" };
        private List<Member> membersList = new List<Member>
        {
            new Member
            {
                FirstName = "Steve",
                LastName = "Robert",
                Address = "1 Infinite Loop, Cupertino, California",
                MemberId = "M9999"
            },
            new Member
            {
                 FirstName = "Adam",
                LastName = "Taylor",
                Address = "5 Cherry Springs,Redmond, Washington, United States",
                MemberId = "M8888"
            }
        };
       [HttpGet("[action]/{memberId}")]
       [Authorize(Roles = "Members.Readonly")]
        public IActionResult GetMemberInfo(string memberId)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            var member = membersList.FirstOrDefault(x => x.MemberId == memberId);
            if(member==null)
                return NotFound();
            return Ok(member);
        }
    }
}
