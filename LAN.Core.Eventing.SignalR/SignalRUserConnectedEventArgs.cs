using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	[ImmutableObject(true)]
	public class SignalRUserConnectedEventArgs : EventArgs
	{
		public IPrincipal Principal { get; private set; }
		public IConnectionContext Context { get; private set; }

		public SignalRUserConnectedEventArgs(IPrincipal principal, IConnectionContext context)
		{
			Contract.Requires(principal != null);
			Contract.Requires(context != null);

			if (principal == null) throw new ArgumentNullException("principal");
			if (context == null) throw new ArgumentNullException("context");

			Contract.Ensures(this.Principal != null);
			Contract.Ensures(this.Context != null);

			this.Principal = principal;
			this.Context = Context;
		}
	}
}