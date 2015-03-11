using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR.Hubs;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRConnectionContext : IConnectionContext
	{
		public SignalRConnectionContext(HubCallerContext context)
		{
			this.Url = context.Request.Url;
			this.Headers = context.Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
			this.QueryString = context.Request.QueryString.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
			this.CorrelationId = context.ConnectionId;
		}

		public Uri Url { get; private set; }
		public Dictionary<string, string> Headers { get; private set; }
		public Dictionary<string, string> QueryString { get; private set; }
		public string CorrelationId { get; private set; }
	}
}