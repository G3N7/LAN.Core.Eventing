using System.Diagnostics.Contracts;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(GroupRegistrarContract))]
	public interface IGroupRegistrar
	{
		Task<string[]> GetGroupsForUser(IPrincipal principal, IConnectionContext connectionContext);
	}

	[ContractClassFor(typeof(IGroupRegistrar))]
	abstract class GroupRegistrarContract : IGroupRegistrar
	{
		Task<string[]> IGroupRegistrar.GetGroupsForUser(IPrincipal usersName, IConnectionContext connectionContext)
		{
			Contract.Ensures(Contract.Result<Task<string[]>>() != null);
			throw new System.NotImplementedException();
		}
	}
}