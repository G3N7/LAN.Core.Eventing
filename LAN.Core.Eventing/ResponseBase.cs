using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	public abstract class ResponseBase
	{
		protected ResponseBase(RequestBase request)
		{
			Contract.Requires(request != null);
			Contract.Ensures(this.CorrelationId != null);
			CorrelationId = request?.ConnectionContext?.CorrelationId ?? string.Empty;
		}
		public string CorrelationId { get; set; }
	}
}
