using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof (GroupLookupServiceContract))]
	public interface IGroupLookupService
	{
		IEnumerable<string> GetSignalRGroupsForConnectionId(string connectionId);
	}

	[ContractClassFor(typeof (IGroupLookupService))]
	abstract class GroupLookupServiceContract : IGroupLookupService
	{
		public IEnumerable<string> GetSignalRGroupsForConnectionId(string connectionId)
		{
			Contract.Requires(connectionId != null);
			throw new System.NotImplementedException();
		}
	}
}