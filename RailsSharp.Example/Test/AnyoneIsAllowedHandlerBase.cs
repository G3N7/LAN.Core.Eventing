using System.Security.Principal;
using LAN.Core.Eventing;

namespace RailsSharp.Example.Test
{
	public abstract class AnyoneIsAllowedHandlerBase<TRequest> : HandlerBase<TRequest, IPrincipal> where TRequest : RequestBase
	{
		protected override bool IsAuthorized(TRequest request, IPrincipal principal)
		{
			return true;
		}
	}
}