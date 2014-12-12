using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(ContractMessagingContext))]
	public interface IMessagingContext
	{
		void PublishToClient(EventName name, ResponseBase response);
		void PublishToAll(EventName name, ResponseBase response);
		void PublishToGroup(string groupName, EventName name, ResponseBase response);
		void PublishToGroups(string[] groupNames, EventName name, ResponseBase response);
		void PushToGroup(string groupName, EventName name, PushBase pushMessage);
		void PushToGroups(string[] groupNames, EventName name, PushBase pushMessage);
	}

	[ContractClassFor(typeof(IMessagingContext))]
	abstract class ContractMessagingContext : IMessagingContext
	{
		void IMessagingContext.PublishToClient(EventName name, ResponseBase response)
		{
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			throw new System.NotImplementedException();
		}

		void IMessagingContext.PublishToAll(EventName name, ResponseBase response)
		{
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			throw new System.NotImplementedException();
		}

		void IMessagingContext.PublishToGroup(string groupName, EventName name, ResponseBase response)
		{
			Contract.Requires(groupName != null);
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			throw new System.NotImplementedException();
		}

		void IMessagingContext.PublishToGroups(string[] groupNames, EventName name, ResponseBase response)
		{
			Contract.Requires(groupNames != null);
			Contract.Requires(name != null);
			Contract.Requires(response != null);
			throw new System.NotImplementedException();
		}

		public void PushToGroup(string groupName, EventName name, PushBase pushMessage)
		{
			Contract.Requires(groupName != null);
			Contract.Requires(name != null);
			Contract.Requires(pushMessage != null);
			throw new System.NotImplementedException();
		}

		public void PushToGroups(string[] groupNames, EventName name, PushBase pushMessage)
		{
			Contract.Requires(groupNames != null);
			Contract.Requires(name != null);
			Contract.Requires(pushMessage != null);
			throw new System.NotImplementedException();
		}
	}
}