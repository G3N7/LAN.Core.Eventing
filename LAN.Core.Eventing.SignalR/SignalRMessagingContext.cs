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

		public void PublishToClient(EventName name, ResponseBase response)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Clients.Client(response.CorrelationId).eventReceived(name.ToString(), _signalRSerializer.Serialize(response));
		}

		public void PublishToAll(EventName name, ResponseBase response)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Clients.All.eventReceived(name.ToString(), _signalRSerializer.Serialize(response));
		}

		public void PublishToGroup(string groupName, EventName name, ResponseBase response)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Clients.Group(groupName, response.CorrelationId).eventReceived(name.ToString(), _signalRSerializer.Serialize(response));
		}

		public void PublishToGroups(string[] groupNames, EventName name, ResponseBase response)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Clients.Groups(groupNames, response.CorrelationId).eventReceived(name.ToString(), _signalRSerializer.Serialize(response));
		}

		public void PushToGroup(string groupName, EventName name, PushBase pushMessage)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Clients.Group(groupName).eventReceived(name.ToString(), _signalRSerializer.Serialize(pushMessage));
		}

		public void PushToGroups(string[] groupNames, EventName name, PushBase pushMessage)
		{
			var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub>();
			context.Clients.Groups(groupNames).eventReceived(name.ToString(), _signalRSerializer.Serialize(pushMessage));
		}
	}
}