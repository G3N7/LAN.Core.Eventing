using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	[ImmutableObject(true)]
	public class SignalRExceptionEventArgs : EventArgs
	{
		public SignalRExceptionEventArgs(IPrincipal principal, Exception ex, IConnectionContext context, string associatedEventName)
		{
			Contract.Requires(principal != null);
			Contract.Requires(ex != null);
			Contract.Requires(context != null);

			if (principal == null) throw new ArgumentNullException("principal");
			if (ex == null) throw new ArgumentNullException("ex");
			if (context == null) throw new ArgumentNullException("context");

			Contract.Ensures(this.Principal != null);
			Contract.Ensures(this.Exception != null);
			Contract.Ensures(this.Context != null);

			this.Principal = principal;
			this.Exception = ex;
			this.Context = context;
			this.AssociatedEventName = associatedEventName;
		}

		/// <summary>
		/// If the exception occurred durring the invocation of an event, the events name will be populated.
		/// </summary>
		public string AssociatedEventName { get; set; }
		/// <summary>
		/// The connection context active when this exception occurred.
		/// </summary>
		public IConnectionContext Context { get; private set; }
		/// <summary>
		/// The principle active when this exception occurred.
		/// </summary>
		public IPrincipal Principal { get; private set; }
		/// <summary>
		/// The actual exception (and inner exception(s)) that occurred.
		/// </summary>
		public Exception Exception { get; private set; }
	}
}