using System;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRExceptionEventArgs : EventArgs
	{
		public SignalRExceptionEventArgs(Exception ex, string connectionId)
		{
			this.Exception = ex;
			this.ConnectionId = connectionId;
		}

		public string ConnectionId { get; private set; }

		public Exception Exception { get; private set; }
	}
}