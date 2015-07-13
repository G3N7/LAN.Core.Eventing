using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof (GroupLeaveServiceContract))]
	public interface IGroupLeaveService
	{
		/// <summary>
		/// Used to leave a group in flight.  You can add registrations using (<see cref="IGroupJoinService.JoinToGroup"/>).
		/// </summary>
		/// <param name="groupToLeave">A unique name for the group to leave.</param>
		/// <param name="connectionId">The id of the connection that should no longer recieve messages from the group.</param>
		void LeaveGroup(string groupToLeave, string connectionId);
	}

	[ContractClassFor(typeof (IGroupLeaveService))]
	abstract class GroupLeaveServiceContract : IGroupLeaveService
	{
		void IGroupLeaveService.LeaveGroup(string groupToLeave, string uniqueId)
		{
			Contract.Requires(groupToLeave != null);
			Contract.Requires(uniqueId != null);
			throw new System.NotImplementedException();
		}
	}
}
