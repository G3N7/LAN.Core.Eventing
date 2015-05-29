using LAN.Core.DependencyInjection;
using LAN.Core.Eventing;
using LAN.Core.Eventing.SignalR;

namespace RailsSharp.Example
{
	public class CompositionConfig
	{
		public static IHandlerRepository ConfigureApp(IContainer container)
		{
			container.Bind<ISignalRSerializer, CamelCaseSignalRSerializer>(true);
			container.Bind<IMessagingContext, SignalRMessagingContext>(true);
			var groupService = new SignalRGroupService();
			container.RegisterSingleton<IGroupJoinService>(groupService);
			container.RegisterSingleton<IGroupLeaveService>(groupService);
			container.RegisterSingleton<IGroupLookupService>(groupService);
			container.Bind<ISignalRGroupRegistrar, GroupRegistrar>(true);
			container.Bind<ISignalRConnectionLookupService, SignalRConnectionLookupService>(true);

			var handlerRepository = new DIHandlerRepository(container);
			container.RegisterSingleton<IHandlerRepository>(handlerRepository);
			return handlerRepository;
		}
	}
}