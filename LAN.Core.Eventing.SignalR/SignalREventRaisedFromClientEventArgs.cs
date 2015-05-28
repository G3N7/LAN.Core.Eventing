using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing.SignalR
{
	[ImmutableObject(true)]
	public class SignalREventRaisedFromClientEventArgs : EventArgs
	{
		public SignalREventRaisedFromClientEventArgs(string eventName, RequestBase request, IConnectionContext context)
		{
			Contract.Requires(eventName != null);
			Contract.Requires(request != null);
			Contract.Requires(context != null);

			if (eventName == null) throw new ArgumentNullException("eventName");
			if (request == null) throw new ArgumentNullException("request");
			if (context == null) throw new ArgumentNullException("context");

			Contract.Ensures(this.EventName != null);
			Contract.Ensures(this.Request != null);
			Contract.Ensures(this.Context != null);

			this.EventName = eventName;
			this.Request = request;
			this.Context = context;
		}

		public string EventName { get; private set; }
		public RequestBase Request { get; private set; }
		public IConnectionContext Context { get; set; }
	}
}