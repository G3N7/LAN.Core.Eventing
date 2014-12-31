using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Core.Eventing.SignalR
{
	[Serializable]
	public class SignalREventingException : Exception
	{
		public SignalREventingException() { }
		public SignalREventingException(string message) : base(message) { }
		public SignalREventingException(string message, Exception inner) : base(message, inner) { }
		protected SignalREventingException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}
