using System.Security.Principal;
using System.Threading.Tasks;
using LAN.Core.Eventing;

namespace RailsSharp.Example.Test
{
	public class TestSingleHandler : AnyoneIsAllowedHandlerBase<TestSingleRequest>
	{
		private readonly IMessagingContext _messagingContext;

		public TestSingleHandler(IMessagingContext messagingContext)
		{
			_messagingContext = messagingContext;
		}

		protected async override Task Invoke(TestSingleRequest request, IPrincipal principal)
		{
			await _messagingContext.PublishToClient(TestEvents.TestSingleResponse, new TestSingleResponse(request));
		}
	}
}