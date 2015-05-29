using System.Security.Principal;
using LAN.Core.Eventing;

namespace RailsSharp.Example.Test
{
	public class TestSingleHandler : AnyoneIsAllowedHandlerBase
	{
		private readonly IMessagingContext _messagingContext;

		public TestSingleHandler(IMessagingContext messagingContext)
		{
			_messagingContext = messagingContext;
		}

		protected override void Invoke(TestSingleRequest request, IPrincipal principal)
		{
			_messagingContext.PublishToClient(TestEvents.TestSingleResponse, new TestSingleResponse(request));
		}
	}
}