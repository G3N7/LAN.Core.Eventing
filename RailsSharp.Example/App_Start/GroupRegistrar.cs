using System.Security.Principal;
using System.Threading.Tasks;
using LAN.Core.Eventing;

namespace RailsSharp.Example
{
	internal class GroupRegistrar : GroupRegistrarBase<GenericPrincipal>
	{
		public override Task<string[]> GetGroupsForUser(GenericPrincipal usersName, IConnectionContext connectionContext)
		{
			return Task.Factory.StartNew(() => new string[0]);
		}
	}
}