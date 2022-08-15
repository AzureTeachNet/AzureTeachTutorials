using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationAgentApi.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private List<AgentMemberHistory> agentMemberHistoryList
            = new List<AgentMemberHistory>
            {
                new AgentMemberHistory
                {
                    AgentName="Andria",
                    ReasonForCall="Issue with the billing",
                    InteractionDate = DateTime.Now
                },
                new AgentMemberHistory
                {
                    AgentName="Robert",
                    ReasonForCall="Issue with the billing",
                    InteractionDate = DateTime.Now
                }
            };
        static readonly string[] scopeRequiredByApi = new string[] { "OperationsAgent.All" };

        private readonly IDownstreamWebApi _downstreamWebApi;

        public AgentController(IDownstreamWebApi downstreamWebApi)
        {
            _downstreamWebApi = downstreamWebApi;
        }

        [HttpGet("[action]/{memberId}")]
        [Authorize(Roles = "OperationsAgent")]
        public async Task<IActionResult> GetAgentMemberHistory(string memberId)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            var memberInfo = await _downstreamWebApi.CallWebApiForUserAsync<Member>("MembersApi",
                options =>
                {
                    options.RelativePath = $"Members/GetMemberInfo/{memberId}";
                    
                });
            return Ok(new AgentMemberHistoryResponse
            {
                MemberInfo = memberInfo,
                AgentMemberHistory = agentMemberHistoryList
            });
        }
    }
}
