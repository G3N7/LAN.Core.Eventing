using System;
using System.Security.Principal;
using System.Threading.Tasks;

namespace RailsSharp.Example.Test
{
	public class TestFailedHandler : AnyoneIsAllowedHandlerBase<TestFailedRequest>
	{
		protected override Task Invoke(TestFailedRequest request, IPrincipal principal)
		{
			throw new Exception();
		}
	}
}