using System.Security.Principal;
using System.Threading.Tasks;
using LAN.Core.Eventing;

namespace RailsSharp.Example.Test
{
	public class TestUnauthorizedHandler : AsyncHandlerBase<TestUnauthorizedRequest, IPrincipal>
	{
		protected override Task<bool> IsAuthorized(TestUnauthorizedRequest request, IPrincipal principal)
		{
			return Task.FromResult(false);
		}

		protected override Task Invoke(TestUnauthorizedRequest request, IPrincipal principal)
		{
			return Task.FromResult(false);
		}
	}
}