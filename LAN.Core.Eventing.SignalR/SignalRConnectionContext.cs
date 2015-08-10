using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Microsoft.AspNet.SignalR.Hubs;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRConnectionContext : IConnectionContext
	{
		public SignalRConnectionContext(HubCallerContext context)
		{
			Contract.Requires(context != null);

			if (context == null) throw new ArgumentNullException(nameof(context));

			Contract.Ensures(QueryString != null);
			
			this.QueryString = context.QueryString.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
			this.CorrelationId = context.ConnectionId;
		}

		public Dictionary<string, string> QueryString { get; private set; }
		public string CorrelationId { get; private set; }
	}
}