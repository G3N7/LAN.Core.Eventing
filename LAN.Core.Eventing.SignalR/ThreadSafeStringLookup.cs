using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LAN.Core.Eventing.SignalR
{
	public sealed class ThreadSafeStringLookup
	{
		public ThreadSafeStringLookup()
		{
			_strings = new List<string>();
			_lock = new object();
		}

		private readonly object _lock;
		private readonly List<string> _strings;
		public IEnumerable<string> Strings => _strings.AsEnumerable();

		public void AddConnectionId(string connectionId)
		{
			EnterLock();
			try
			{
				if (!this._strings.Contains(connectionId))
				{
					this._strings.Add(connectionId);
				}
			}
			finally
			{
				ExitLock();
			}
		}

		public void RemoveConnectionId(string connectionId)
		{
			EnterLock();
			try
			{
				if (this._strings.Contains(connectionId))
				{
					this._strings.Remove(connectionId);
				}
			}
			finally
			{
				ExitLock();
			}
		}

		private void EnterLock()
		{
			Monitor.Enter(this._lock);
		}

		private void ExitLock()
		{
			Monitor.Exit(this._lock);
		}
	}
}