using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	[ImmutableObject(true)]
	public class SignalRExceptionEventArgs : EventArgs
	{
		public SignalRExceptionEventArgs(IPrincipal principal, Exception ex, IConnectionContext context)
		{
			Contract.Requires(principal != null);
			Contract.Requires(ex != null);
			Contract.Requires(context != null);

			if (principal == null) throw new ArgumentNullException(nameof(principal));
			if (ex == null) throw new ArgumentNullException(nameof(ex));
			if (context == null) throw new ArgumentNullException(nameof(context));

			Contract.Ensures(this.Principal != null);
			Contract.Ensures(this.Exception != null);
			Contract.Ensures(this.Context != null);

			this.Principal = principal;
			this.Exception = ex;
			this.Context = context;
		}

		public IConnectionContext Context { get; private set; }
		public IPrincipal Principal { get; private set; }
		public Exception Exception { get; private set; }
	}
}