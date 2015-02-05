using System;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRExceptionEventArgs : EventArgs
	{
		public SignalRExceptionEventArgs(IPrincipal principal, Exception ex, string connectionId)
		{
			this.Principal = principal;
			this.Exception = ex;
			this.ConnectionId = connectionId;
		}

		public string ConnectionId { get; private set; }
		public IPrincipal Principal { get; private set; }
		public Exception Exception { get; private set; }
	}
}