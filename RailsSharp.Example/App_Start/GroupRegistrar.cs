using System.Threading.Tasks;
using LAN.Core.Eventing;
using LAN.Core.Eventing.SignalR;

namespace RailsSharp.Example
{
	internal class GroupRegistrar : ISignalRGroupRegistrar
	{
		public Task<string[]> GetGroupsForUser(string usersName, IConnectionContext connectionContext)
		{
			return Task.Factory.StartNew(() => new string[0]);
		}
	}
}