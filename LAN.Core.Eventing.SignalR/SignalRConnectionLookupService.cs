using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRConnectionLookupService : ISignalRConnectionLookupService
	{
		protected static ConcurrentDictionary<string, ThreadSafeStringLookup> ConnectionLookups { get; private set; }
		static SignalRConnectionLookupService()
		{
			ConnectionLookups = new ConcurrentDictionary<string, ThreadSafeStringLookup>();
			SignalREventHub.UserConnected += SignalREventHubOnUserConnected;
			SignalREventHub.UserDisconnected += SignalREventHubOnUserDisconnected;
		}

		private static void SignalREventHubOnUserDisconnected(object sender, SignalRUserDisconnectedEventArgs signalRUserDisconnectedEventArgs)
		{
			ThreadSafeStringLookup lookup;
			if (ConnectionLookups.TryGetValue(signalRUserDisconnectedEventArgs.Principal.Identity.Name, out lookup))
			{
				lookup.RemoveConnectionId(signalRUserDisconnectedEventArgs.ConnectionContext.CorrelationId);
			}
		}

		private static void SignalREventHubOnUserConnected(object sender, SignalRUserConnectedEventArgs signalRUserConnectedEventArgs)
		{
			var lookup = ConnectionLookups.GetOrAdd(
				signalRUserConnectedEventArgs.Principal.Identity.Name,
				s => new ThreadSafeStringLookup());

			lookup.AddConnectionId(signalRUserConnectedEventArgs.ConnectionContext.CorrelationId);
		}

		public IEnumerable<string> GetByIdentityName(string identityName)
		{
			ThreadSafeStringLookup lookup;
			return ConnectionLookups.TryGetValue(identityName, out lookup) ? lookup.Strings.AsEnumerable() : Enumerable.Empty<string>();
		}
	}
}
