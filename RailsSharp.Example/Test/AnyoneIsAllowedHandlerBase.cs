using System.Security.Principal;
using LAN.Core.Eventing;

namespace RailsSharp.Example.Test
{
	public abstract class AnyoneIsAllowedHandlerBase : HandlerBase<TestSingleRequest, IPrincipal>
	{
		protected override bool IsAuthorized(TestSingleRequest request, IPrincipal principal)
		{
			return true;
		}
	}
}