using System;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRUserDisconnectedEventArgs : EventArgs
	{
		public IPrincipal Principal { get; private set; }
		public IConnectionContext ConnectionContext { get; private set; }

		public SignalRUserDisconnectedEventArgs(IPrincipal principal, IConnectionContext connectionContext)
		{
			this.Principal = principal;
			this.ConnectionContext = connectionContext;
		}
	}
}