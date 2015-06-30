using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(ContractMessagingContext))]
	public interface IMessagingContext
	{
		Task PublishToClient(EventName name, ResponseBase response);
		Task PublishToAll(EventName name, ResponseBase response);
		Task PublishToGroup(string groupName, EventName name, ResponseBase response);
		Task PublishToGroups(string[] groupNames, EventName name, ResponseBase response);
		Task PushToGroup(string groupName, EventName name, PushBase pushMessage);
		Task PushToGroups(string[] groupNames, EventName name, PushBase pushMessage);
	}

	[ContractClassFor(typeof(IMessagingContext))]
	abstract class ContractMessagingContext : IMessagingContext
	{
		Task IMessagingContext.PublishToClient(EventName name, ResponseBase response)
		{
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PublishToAll(EventName name, ResponseBase response)
		{
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PublishToGroup(string groupName, EventName name, ResponseBase response)
		{
			Contract.Requires(groupName != null);
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PublishToGroups(string[] groupNames, EventName name, ResponseBase response)
		{
			Contract.Requires(groupNames != null);
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PushToGroup(string groupName, EventName name, PushBase pushMessage)
		{
			Contract.Requires(groupName != null);
			Contract.Requires(name != null);
			Contract.Requires(pushMessage != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PushToGroups(string[] groupNames, EventName name, PushBase pushMessage)
		{
			Contract.Requires(groupNames != null);
			Contract.Requires(name != null);
			Contract.Requires(pushMessage != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}
	}
}