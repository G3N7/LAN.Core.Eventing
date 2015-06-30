using System;
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
			return _callClient(context =>
				context.Clients.Client(response.CorrelationId)
				.EventReceived(name.ToString(), _signalRSerializer.Serialize(response)));
		}
			
		public Task PublishToAll(EventName name, ResponseBase response)
		{
			return _callClient(
				context => 
					context.Clients.All
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(response)));
		}

		public Task PublishToGroup(string groupName, EventName name, ResponseBase response)
		{
			return _callClient(
				context => 
					context.Clients.Group(groupName, response.CorrelationId)
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(response)));
		}

		public Task PublishToGroups(string[] groupNames, EventName name, ResponseBase response)
		{
			return _callClient(
				context => 
					context.Clients.Groups(groupNames, response.CorrelationId)
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(response)));
		}

		public Task PushToGroup(string groupName, EventName name, PushBase pushMessage)
		{
			return _callClient(
				context =>
					context.Clients.Group(groupName)
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(pushMessage)));
		}

		public Task PushToGroups(string[] groupNames, EventName name, PushBase pushMessage)
		{
			return _callClient(
				context =>
					context.Clients.Groups(groupNames)
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(pushMessage)));
		}

		private Task _callClient(Action<IHubContext<IEventHubClient>> invocation)
		{
			return Task.Factory.StartNew(() =>
			{
				var context = GlobalHost.ConnectionManager.GetHubContext<SignalREventHub, IEventHubClient>();
				invocation(context);
			});
		}
	}
}