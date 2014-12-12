using Microsoft.AspNet.SignalR;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRGroupService : IGroupJoinService, IGroupLeaveService
	{
		public void JoinToGroup(string groupToJoin, string uniqueId)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Groups.Add(uniqueId, groupToJoin);
		}

		public void LeaveGroup(string groupToLeave, string uniqueId)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Groups.Remove(uniqueId, groupToLeave);
		}
	}
}