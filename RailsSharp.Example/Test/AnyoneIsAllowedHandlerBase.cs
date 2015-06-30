using System.Security.Principal;
using System.Threading.Tasks;
using LAN.Core.Eventing;

namespace RailsSharp.Example.Test
{
	public abstract class AnyoneIsAllowedHandlerBase<TRequest> : AsyncHandlerBase<TRequest, IPrincipal> where TRequest : RequestBase
	{
		protected override Task<bool> IsAuthorized(TRequest request, IPrincipal principal)
		{
			return Task.FromResult(true);
		}
	}
}