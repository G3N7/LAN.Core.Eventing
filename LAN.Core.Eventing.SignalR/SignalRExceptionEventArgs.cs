using System;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRExceptionEventArgs : EventArgs
	{
		public SignalRExceptionEventArgs(Exception ex)
		{
			this.Exception = ex;
		}
		public Exception Exception { get; private set; }
	}
}