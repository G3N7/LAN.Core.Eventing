using System.Security.Principal;
using System.Threading.Tasks;

namespace LAN.Core.Eventing
{
	public abstract class GroupRegistrarBase<TPrincipal> : IGroupRegistrar where TPrincipal : IPrincipal
	{
		public abstract Task<string[]> GetGroupsForUser(TPrincipal usersName, IConnectionContext connectionContext);

		public Task<string[]> GetGroupsForUser(IPrincipal principal, IConnectionContext connectionContext)
		{
			return this.GetGroupsForUser((TPrincipal)principal, connectionContext);
		}
	}
}