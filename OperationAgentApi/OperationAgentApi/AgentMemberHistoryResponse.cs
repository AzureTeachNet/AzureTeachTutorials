using System.Collections.Generic;

namespace OperationAgentApi
{
    public class AgentMemberHistoryResponse
    {
        public Member MemberInfo { get; set; }
        public List<AgentMemberHistory> AgentMemberHistory { get; set; }
    }
}
