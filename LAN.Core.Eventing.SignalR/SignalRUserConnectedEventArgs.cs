using System;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRUserConnectedEventArgs : EventArgs
	{
		public IPrincipal Principal { get; private set; }
		public IConnectionContext ConnectionContext { get; private set; }

		public SignalRUserConnectedEventArgs(IPrincipal principal, IConnectionContext connectionContext)
		{
			this.Principal = principal;
			this.ConnectionContext = connectionContext;
		}
	}
}