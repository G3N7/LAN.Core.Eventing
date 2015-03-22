using System;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRExceptionEventArgs : EventArgs
	{
		public SignalRExceptionEventArgs(IPrincipal principal, Exception ex, IConnectionContext context)
		{
			this.Principal = principal;
			this.Exception = ex;
			this.Context = context;
		}

		public IConnectionContext Context { get; private set; }
		public IPrincipal Principal { get; private set; }
		public Exception Exception { get; private set; }
	}
}