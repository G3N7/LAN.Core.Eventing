using System;
using System.Diagnostics;
using System.Security.Authentication;
using System.Threading.Tasks;
using LAN.Core.DependencyInjection;
using LAN.Core.Eventing.Server;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json.Linq;

namespace LAN.Core.Eventing.SignalR
{
	[HubName("eventHub")]
	public class SignalREventHub : Hub
	{
		private readonly IMessagingContext _messagingContext;
		private readonly IHandlerRepository _handlerRepository;
		private readonly ISignalRGroupRegistrar _groupRegistrar;
		private readonly IGroupJoinService _groupJoinService;
		private readonly IGroupLeaveService _groupLeaveService;
		
		public SignalREventHub()
		{
			var container = ContainerRegistery.DefaultContainer;
			this._handlerRepository = container.GetInstance<IHandlerRepository>();
			this._messagingContext = container.GetInstance<IMessagingContext>();
			this._groupRegistrar = container.GetInstance<ISignalRGroupRegistrar>();
			this._groupJoinService = container.GetInstance<IGroupJoinService>();
			this._groupLeaveService = container.GetInstance<IGroupLeaveService>();
		}

		public override Task OnConnected()
		{
			var username = this.Context.User.Identity.Name;
			if (!this.Context.User.Identity.IsAuthenticated) return base.OnConnected();
			try
			{
				var groupsToJoin = this._groupRegistrar.GetGroupsForUser(username);
				foreach (var groupToJoin in groupsToJoin.Result)
				{
					this._groupJoinService.JoinToGroup(groupToJoin, this.Context.ConnectionId);
					Debug.WriteLine("SignalR: {0} has joined group {1}", username, groupToJoin);
				}
			}
			catch (Exception)
			{
				SendError("Error Joining Groups");
			}

			return base.OnConnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			var username = this.Context.User.Identity.Name;
			if (!this.Context.User.Identity.IsAuthenticated) return base.OnDisconnected(stopCalled);
			try
			{
				var groupsToLeave = this._groupRegistrar.GetGroupsForUser(username);
				foreach (var groupToJoin in groupsToLeave.Result)
				{
					this._groupLeaveService.LeaveGroup(groupToJoin, this.Context.ConnectionId);
					Debug.WriteLine("SignalR: {0} has left group {1}", username, groupToJoin);
				}
			}
			catch (Exception)
			{
				SendError("Error Leaving Groups");
			}

			return base.OnDisconnected(stopCalled);
		}

		[HubMethodName("raiseEvent")]
		// ReSharper disable once UnusedMember.Global
		public void RaiseEvent(string eventName, JObject data)
		{
			try
			{
				IHandler handler;
				if (!this._handlerRepository.TryGetHandler(eventName, out handler))
				{
					var errorMessage = string.Format(
						"The event {0} is not a known event, there are only a few things this could be, check that you have Registered the Handler, and that its registered with the event you are emitting, and that all of the handlers dependancies are registered with the DI container.",
						eventName);
					SendError(errorMessage);
					throw new ArgumentException(errorMessage);
				}

				if (!handler.IsAuthorized(this.Context.User))
				{
					var errorMessage = string.Format(
						"Auth: You are not authorized to use the event {0}.",
						eventName);
					SendError(errorMessage);
					throw new AuthenticationException(errorMessage);
				}

				var eventTask = InvokeHandlerAsync(handler, data);
				eventTask.ContinueWith(HandleErrorForAsyncHandler, TaskContinuationOptions.OnlyOnFaulted);
				eventTask.Start();
				Debug.WriteLine("SignalR: {0} has raised {1} event", this.Context.User.Identity.Name, eventName);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
#if DEBUG
				SendError(ex.ToString());
#endif
			}
		}

		private void SendError(string message)
		{
			this._messagingContext.PublishToClient(new EventName(ServerEvents.OnError), new OnErrorResponse(null) { CorrelationId = this.Context.ConnectionId, Message = message });
		}

		private void HandleErrorForAsyncHandler(Task handlerTask)
		{
			SendError(handlerTask.Exception == null ? "UnknownError" : handlerTask.Exception.GetBaseException().Message);
		}

		private Task InvokeHandlerAsync(IHandler handler, JObject data)
		{
			return new Task(() =>
			{
				data.Add("correlationId", this.Context.ConnectionId);
				var deserializedRequest = data.ToObject(handler.GetRequestType());
				handler.Invoke((RequestBase)deserializedRequest, this.Context.User);
			});
		}
	}
}
