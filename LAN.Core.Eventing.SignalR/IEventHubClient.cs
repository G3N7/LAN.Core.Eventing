using System.Diagnostics.Contracts;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json.Linq;

namespace LAN.Core.Eventing.SignalR
{
	[ContractClass(typeof(EventHubClientContract))]
	public interface IEventHubClient
	{
		[HubMethodName("eventRecieved")]
		void EventReceived(string eventName, JObject response);
	}

	[ContractClassFor(typeof(IEventHubClient))]
	abstract class EventHubClientContract : IEventHubClient
	{
		void IEventHubClient.EventReceived(string eventName, JObject response)
		{
			throw new System.NotImplementedException();
		}
	}
}