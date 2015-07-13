using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(ContractMessagingContext))]
	public interface IMessagingContext
	{
		Task PublishToClient<TResponse>(EventName name, TResponse response) where TResponse : ResponseBase;
		Task PublishToAll<TResponse>(EventName name, TResponse response) where TResponse : ResponseBase;
		Task PublishToGroup<TResponse>(string groupName, EventName name, TResponse response) where TResponse : ResponseBase;
		Task PublishToGroups<TResponse>(string[] groupNames, EventName name, TResponse response) where TResponse : ResponseBase;
		Task PushToGroup<TPush>(string groupName, EventName name, TPush pushMessage) where TPush : PushBase;
		Task PushToGroups<TPush>(string[] groupNames, EventName name, TPush pushMessage) where TPush : PushBase;
	}

	[ContractClassFor(typeof(IMessagingContext))]
	abstract class ContractMessagingContext : IMessagingContext
	{
		Task IMessagingContext.PublishToClient<TResponse>(EventName name, TResponse response)
		{
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PublishToAll<TResponse>(EventName name, TResponse response)
		{
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PublishToGroup<TResponse>(string groupName, EventName name, TResponse response)
		{
			Contract.Requires(groupName != null);
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PublishToGroups<TResponse>(string[] groupNames, EventName name, TResponse response)
		{
			Contract.Requires(groupNames != null);
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PushToGroup<TPush>(string groupName, EventName name, TPush pushMessage)
		{
			Contract.Requires(groupName != null);
			Contract.Requires(name != null);
			Contract.Requires(pushMessage != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}

		Task IMessagingContext.PushToGroups<TPush>(string[] groupNames, EventName name, TPush pushMessage)
		{
			Contract.Requires(groupNames != null);
			Contract.Requires(name != null);
			Contract.Requires(pushMessage != null);
			Contract.Ensures(Contract.Result<Task>() != null);
			throw new System.NotImplementedException();
		}
	}
}