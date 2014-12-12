using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace LAN.Core.Eventing.SignalR
{
	[ContractClass(typeof(SignalRGroupRegistrarContract))]
	public interface ISignalRGroupRegistrar
	{
		Task<string[]> GetGroupsForUser(string usersName);
	}

	[ContractClassFor(typeof(ISignalRGroupRegistrar))]
	abstract class SignalRGroupRegistrarContract : ISignalRGroupRegistrar
	{
		Task<string[]> ISignalRGroupRegistrar.GetGroupsForUser(string usersName)
		{
			Contract.Requires(usersName != null);
			Contract.Ensures(Contract.Result<Task<string[]>>() != null);
			throw new System.NotImplementedException();
		}
	}
}