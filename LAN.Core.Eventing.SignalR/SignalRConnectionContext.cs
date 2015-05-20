using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR.Hubs;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRConnectionContext : IConnectionContext
	{
		public SignalRConnectionContext(HubCallerContext context)
		{
			this.QueryString = context.QueryString.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
			this.CorrelationId = context.ConnectionId;
		}

		public Dictionary<string, string> QueryString { get; private set; }
		public string CorrelationId { get; private set; }
	}
}