using System.Collections.Generic;

namespace LAN.Core.Eventing
{
	public interface IConnectionContext
	{
		Dictionary<string, string> QueryString { get; }
		string CorrelationId { get; }
	}
}