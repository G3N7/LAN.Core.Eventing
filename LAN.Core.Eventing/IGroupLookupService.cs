using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof (IGroupLookupServiceContract))]
	public interface IGroupLookupService
	{
		IEnumerable<string> GetSignalRGroupsForConnectionId(string connectionId);
	}

	[ContractClassFor(typeof (IGroupLookupService))]
	abstract class IGroupLookupServiceContract : IGroupLookupService
	{
		public IEnumerable<string> GetSignalRGroupsForConnectionId(string connectionId)
		{
			Contract.Requires(connectionId != null);
			throw new System.NotImplementedException();
		}
	}
}