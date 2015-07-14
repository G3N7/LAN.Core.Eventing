using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(ContractMessagingContext))]
	public interface IMessagingContext
	{
		/// <summary>
		/// Publishes a response to the client that initiated the request.
		/// </summary>
		/// <typeparam name="TResponse">The specific type being used to respond.</typeparam>
		/// <param name="name">The <see cref="EventName"/> you wish to sent back to the caller</param>
		/// <param name="response">The body of a response to this request</param>
		/// <returns>A task that will send the response to the client.</returns>
		Task PublishToClient<TResponse>(EventName name, TResponse response) where TResponse : ResponseBase;

		/// <summary>
		/// Publish a response to all connected clients.
		/// </summary>
		/// <typeparam name="TResponse">The specific type being used to respond.</typeparam>
		/// <param name="name">The <see cref="EventName"/> you wish to sent back to the all connected clients.</param>
		/// <param name="response">The body of a response to this request.</param>
		/// <returns>A task that will send the response to all connected clients.</returns>
		Task PublishToAll<TResponse>(EventName name, TResponse response) where TResponse : ResponseBase;

		/// <summary>
		/// Publish a response to all members of a specific group (with the exception of the caller, please also PublishToClient, this is to prevent double dispatch).
		/// </summary>
		/// <typeparam name="TResponse">The specific type being used to respond.</typeparam>
		/// <param name="groupName">The specific group to send too.</param>
		/// <param name="name">The <see cref="EventName"/> you wish to sent back to all members of the group.</param>
		/// <param name="response">The body of a response to this request.</param>
		/// <returns>A task that will send the response to all members of the specified <see cref="groupName"/>.</returns>
		Task PublishToGroup<TResponse>(string groupName, EventName name, TResponse response) where TResponse : ResponseBase;

		/// <summary>
		/// Publish a response to all members of a range of groups (with the exception of the caller, please also PublishToClient, this is to prevent double dispatch).
		/// </summary>
		/// <typeparam name="TResponse">The specific type being used to respond.</typeparam>
		/// <param name="groupNames">the specific set of groups to send too.</param>
		/// <param name="name">The <see cref="EventName"/> you wish to sent back to all members of the groups.</param>
		/// <param name="response">The body of a response to this request.</param>
		/// <returns>A task that will send the response to all members of the specified <see cref="groupNames"/>.</returns>
		Task PublishToGroups<TResponse>(string[] groupNames, EventName name, TResponse response) where TResponse : ResponseBase;

		/// <summary>
		/// Push a message to all members of a specific group.
		/// </summary>
		/// <typeparam name="TPush">The specific type being used to push to the group.</typeparam>
		/// <param name="groupName">The specific group to send too.</param>
		/// <param name="name">The <see cref="EventName"/> you wish to be pushed to all members of the groups</param>
		/// <param name="pushMessage">The body of the message to push to the group</param>
		/// <returns>A task that will push the message to all members of the specified <see cref="groupName"/>.</returns>
		Task PushToGroup<TPush>(string groupName, EventName name, TPush pushMessage) where TPush : PushBase;

		/// <summary>
		/// Push a message to all members of a specific groups.
		/// </summary>
		/// <typeparam name="TPush">The specific type being used to push to the group.</typeparam>
		/// <param name="groupNames">the specific set of groups to send too.</param>
		/// <param name="name">The <see cref="EventName"/> you wish to sent back to all members of the groups.</param>
		/// <param name="pushMessage">The body of the message to push to the groups</param>
		/// <returns>A task that will push the message to all members of the specified <see cref="groupNames"/>.</returns>
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