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
		
		public Task PublishToClient<TResponse>(EventName name, TResponse response) where TResponse : ResponseBase
		{
			return _callClient(context =>
				context.Clients.Client(response.CorrelationId)
				.EventReceived(name.ToString(), _signalRSerializer.Serialize(response)));
		}

		public Task PublishToAll<TResponse>(EventName name, TResponse response) where TResponse : ResponseBase
		{
			return _callClient(
				context =>
					context.Clients.All
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(response)));
		}

		public Task PublishToGroup<TResponse>(string groupName, EventName name, TResponse response) where TResponse : ResponseBase
		{
			return _callClient(
				context =>
					context.Clients.Group(groupName, response.CorrelationId)
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(response)));
		}

		public Task PublishToGroups<TResponse>(string[] groupNames, EventName name, TResponse response) where TResponse : ResponseBase
		{
			return _callClient(
				context =>
					context.Clients.Groups(groupNames, response.CorrelationId)
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(response)));
		}

		public Task PushToGroup<TPush>(string groupName, EventName name, TPush pushMessage) where TPush : PushBase
		{
			return _callClient(
				context =>
					context.Clients.Group(groupName)
					.EventReceived(name.ToString(), _signalRSerializer.Serialize(pushMessage)));
		}

		public Task PushToGroups<TPush>(string[] groupNames, EventName name, TPush pushMessage) where TPush : PushBase
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