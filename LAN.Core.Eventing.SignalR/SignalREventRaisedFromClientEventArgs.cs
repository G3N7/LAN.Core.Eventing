using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing.SignalR
{
	[ImmutableObject(true)]
	public class SignalREventRaisedFromClientEventArgs : EventArgs
	{
		public SignalREventRaisedFromClientEventArgs(string eventName, RequestBase request)
		{
			Contract.Requires(eventName != null);
			Contract.Requires(request != null);

			if (eventName == null) throw new ArgumentNullException("eventName");
			if (request == null) throw new ArgumentNullException("request");

			Contract.Ensures(this.EventName != null);
			Contract.Ensures(this.Request != null);

			EventName = eventName;
			Request = request;
		}

		public string EventName { get; private set; }
		public RequestBase Request { get; private set; }
	}
}