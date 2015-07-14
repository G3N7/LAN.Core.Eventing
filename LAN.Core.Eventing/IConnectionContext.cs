using System.Collections.Generic;

namespace LAN.Core.Eventing
{
	public interface IConnectionContext
	{
		/// <summary>
		/// Query string paramerters provided on the request.
		/// </summary>
		Dictionary<string, string> QueryString { get; }
		/// <summary>
		/// The id for this specific connection.
		/// </summary>
		string CorrelationId { get; }
	}
}