using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRGroupService : IGroupJoinService, IGroupLeaveService, IGroupLookupService
	{
		protected static ConcurrentDictionary<string, ThreadSafeStringLookup> ConnectionLookups { get; private set; }

		public void JoinToGroup(string groupToJoin, string connectionId)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Groups.Add(connectionId, groupToJoin);

			var lookup = ConnectionLookups.GetOrAdd(
				connectionId,
				s => new ThreadSafeStringLookup());

			lookup.AddConnectionId(groupToJoin);

		}

		public void LeaveGroup(string groupToLeave, string connectionId)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Groups.Remove(connectionId, groupToLeave);

			ThreadSafeStringLookup lookup;
			if (ConnectionLookups.TryGetValue(connectionId, out lookup))
			{
				lookup.RemoveConnectionId(connectionId);
			}
		}

		public IEnumerable<string> GetSignalRGroupsForConnectionId(string connectionId)
		{
			ThreadSafeStringLookup lookup;
			return ConnectionLookups.TryGetValue(connectionId, out lookup) ? lookup.Strings.AsEnumerable() : Enumerable.Empty<string>();
		}
	}
}