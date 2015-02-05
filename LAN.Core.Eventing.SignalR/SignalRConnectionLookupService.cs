using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRConnectionLookupService : ISignalRConnectionLookupService
	{
		protected static ConcurrentDictionary<string, ConnectionLookup> ConnectionLookups { get; private set; }
		static SignalRConnectionLookupService()
		{
			ConnectionLookups = new ConcurrentDictionary<string, ConnectionLookup>();
			SignalREventHub.UserConnected += SignalREventHubOnUserConnected;
			SignalREventHub.UserDisconnected += SignalREventHubOnUserDisconnected;
		}

		private static void SignalREventHubOnUserDisconnected(object sender, SignalRUserDisconnectedEventArgs signalRUserDisconnectedEventArgs)
		{
			ConnectionLookup lookup;
			if (ConnectionLookups.TryGetValue(signalRUserDisconnectedEventArgs.Principal.Identity.Name, out lookup))
			{
				lookup.RemoveConnectionId(signalRUserDisconnectedEventArgs.CorrelationId);
			}
		}

		private static void SignalREventHubOnUserConnected(object sender, SignalRUserConnectedEventArgs signalRUserConnectedEventArgs)
		{
			var lookup = ConnectionLookups.GetOrAdd(
				signalRUserConnectedEventArgs.Principal.Identity.Name,
				s => new ConnectionLookup());

			lookup.AddConnectionId(signalRUserConnectedEventArgs.CorrelationId);
		}

		public IEnumerable<string> GetByIdentityName(string identityName)
		{
			ConnectionLookup lookup;
			return ConnectionLookups.TryGetValue(identityName, out lookup) ? lookup.ConnectionIds.AsEnumerable() : Enumerable.Empty<string>();
		}

		protected sealed class ConnectionLookup
		{
			public ConnectionLookup()
			{
				_connectionId = new List<string>();
				_lock = new object();
			}

			private readonly object _lock;
			private readonly List<string> _connectionId;
			public IEnumerable<string> ConnectionIds
			{
				get { return _connectionId.AsEnumerable(); }
			}

			public void AddConnectionId(string connectionId)
			{
				EnterLock();
				try
				{
					if (!this._connectionId.Contains(connectionId))
					{
						this._connectionId.Add(connectionId);
					}
				}
				finally
				{
					ExitLock();
				}
			}

			public void RemoveConnectionId(string connectionId)
			{
				EnterLock();
				try
				{
					if (this._connectionId.Contains(connectionId))
					{
						this._connectionId.Remove(connectionId);
					}
				}
				finally
				{
					ExitLock();
				}
			}

			private void EnterLock()
			{
				Monitor.Enter(this._lock);
			}

			private void ExitLock()
			{
				Monitor.Exit(this._lock);
			}
		}
	}
}
