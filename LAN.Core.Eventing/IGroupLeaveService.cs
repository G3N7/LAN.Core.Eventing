using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof (IGroupLeaveServiceContract))]
	public interface IGroupLeaveService
	{
		void LeaveGroup(string groupToLeave, string uniqueId);
	}

	[ContractClassFor(typeof (IGroupLeaveService))]
	abstract class IGroupLeaveServiceContract : IGroupLeaveService
	{
		void IGroupLeaveService.LeaveGroup(string groupToLeave, string uniqueId)
		{
			Contract.Requires(groupToLeave != null);
			Contract.Requires(uniqueId != null);
			throw new System.NotImplementedException();
		}
	}
}
