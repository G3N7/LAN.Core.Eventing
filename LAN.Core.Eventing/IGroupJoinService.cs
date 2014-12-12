using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof (IGroupJoinServiceContract))]
	public interface IGroupJoinService
	{
		void JoinToGroup(string groupToJoin, string uniqueId);
	}

	[ContractClassFor(typeof (IGroupJoinService))]
	abstract class IGroupJoinServiceContract : IGroupJoinService
	{
		void IGroupJoinService.JoinToGroup(string groupToJoin, string uniqueId)
		{
			Contract.Requires(groupToJoin != null);
			Contract.Requires(uniqueId != null);
			throw new System.NotImplementedException();
		}
	}
}