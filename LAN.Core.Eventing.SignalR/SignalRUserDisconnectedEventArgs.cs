using System;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRUserDisconnectedEventArgs : EventArgs
	{
		public IPrincipal Principal { get; private set; }
		public string CorrelationId { get; private set; }
		
		public SignalRUserDisconnectedEventArgs(IPrincipal principal, string correlationId)
		{
			this.Principal = principal;
			this.CorrelationId = correlationId;
		}
	}
}