using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof (GroupJoinServiceContract))]
	public interface IGroupJoinService
	{
		/// <summary>
		/// Used to join a group in flight.  You should remove this registration when it is no longer valid using (<see cref="IGroupLeaveService.LeaveGroup"/>).
		/// </summary>
		/// <param name="groupToJoin">A unique name for the group to join.</param>
		/// <param name="connectionId">The id of the connection that should recieve messages from the group.</param>
		void JoinToGroup(string groupToJoin, string connectionId);
	}

	[ContractClassFor(typeof (IGroupJoinService))]
	abstract class GroupJoinServiceContract : IGroupJoinService
	{
		void IGroupJoinService.JoinToGroup(string groupToJoin, string connectionId)
		{
			Contract.Requires(groupToJoin != null);
			Contract.Requires(connectionId != null);
			throw new System.NotImplementedException();
		}
	}
}