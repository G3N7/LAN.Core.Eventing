using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace LAN.Core.Eventing.SignalR
{
	public class SignalRMessagingContext : IMessagingContext
	{
		private readonly ISignalRSerializer _signalRSerializer;

		public SignalRMessagingContext(ISignalRSerializer signalRSerializer)
		{
			_signalRSerializer = signalRSerializer;
		}

		public Task PublishToClient(EventName name, ResponseBase response)
		{
			return Task.Factory.StartNew(() =>
				{
					var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
					context.Clients.Client(response.CorrelationId).eventReceived(name.ToString(), _signalRSerializer.Serialize(response));
				}
			);
		}

		public Task PublishToAll(EventName name, ResponseBase response)
		{
			return Task.Factory.StartNew(() =>
				{
					var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
					context.Clients.All.eventReceived(name.ToString(), _signalRSerializer.Serialize(response));
				}
			);
		}

		public Task PublishToGroup(string groupName, EventName name, ResponseBase response)
		{
			return Task.Factory.StartNew(() =>
				{
					var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
					context.Clients.Group(groupName, response.CorrelationId).eventReceived(name.ToString(), _signalRSerializer.Serialize(response));
				}
			);
		}

		public Task PublishToGroups(string[] groupNames, EventName name, ResponseBase response)
		{
			return Task.Factory.StartNew(() =>
				{
					var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
					context.Clients.Groups(groupNames, response.CorrelationId).eventReceived(name.ToString(), _signalRSerializer.Serialize(response));
				}
			);
		}

		public Task PushToGroup(string groupName, EventName name, PushBase pushMessage)
		{
			return Task.Factory.StartNew(() =>
				{
					var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
					context.Clients.Group(groupName).eventReceived(name.ToString(), _signalRSerializer.Serialize(pushMessage));
				}
			);
		}

		public Task PushToGroups(string[] groupNames, EventName name, PushBase pushMessage)
		{
			return Task.Factory.StartNew(() =>
				{
					var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
					context.Clients.Groups(groupNames).eventReceived(name.ToString(), _signalRSerializer.Serialize(pushMessage));
				}
			);
		}
	}
}