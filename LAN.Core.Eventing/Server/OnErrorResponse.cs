using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing.Server
{
	public class OnErrorResponse : ResponseBase
	{
		public OnErrorResponse(RequestBase request)
			: base(request)
		{
			Contract.Requires(request != null);
		}

		public string Message { get; set; }
	}
}