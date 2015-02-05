using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing.SignalR
{
	[ContractClass(typeof(SignalRConnectionLookupServiceContract))]
	public interface ISignalRConnectionLookupService
	{
		IEnumerable<string> GetByIdentityName(string identityName);
	}

	[ContractClassFor(typeof(ISignalRConnectionLookupService))]
	abstract class SignalRConnectionLookupServiceContract : ISignalRConnectionLookupService
	{
		IEnumerable<string> ISignalRConnectionLookupService.GetByIdentityName(string identityName)
		{
			Contract.Requires(identityName != null);
			Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);
			throw new System.NotImplementedException();
		}
	}
}