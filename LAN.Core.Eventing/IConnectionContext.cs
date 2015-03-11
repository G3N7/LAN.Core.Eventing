using System;
using System.Collections.Generic;

namespace LAN.Core.Eventing
{
	public interface IConnectionContext
	{
		Uri Url { get; }
		Dictionary<string, string> Headers { get; }
		Dictionary<string, string> QueryString { get; }
		string CorrelationId { get; }
	}
}