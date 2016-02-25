﻿using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace LAN.Core.Eventing.SignalR
{
	[ImmutableObject(true)]
	public class SignalRUserDisconnectedEventArgs : EventArgs
	{
		public IPrincipal Principal { get; private set; }
		public IConnectionContext Context { get; private set; }

		public SignalRUserDisconnectedEventArgs(IPrincipal principal, IConnectionContext context)
		{
			Contract.Requires(principal != null);
			Contract.Requires(context != null);

			if (principal == null) throw new ArgumentNullException(nameof(principal));
			if (context == null) throw new ArgumentNullException(nameof(context));

			Contract.Ensures(this.Principal != null);
			Contract.Ensures(this.Context != null);

			this.Principal = principal;
			this.Context = context;
		}
	}
}