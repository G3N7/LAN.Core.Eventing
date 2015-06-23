using System;
using System.Security.Principal;

namespace RailsSharp.Example.Test
{
	public class TestFailedHandler : AnyoneIsAllowedHandlerBase<TestFailedRequest>
	{
		protected override void Invoke(TestFailedRequest request, IPrincipal principal)
		{
			throw new Exception();
		}
	}
}