using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(ContractHandlerRepository))]
	public interface IHandlerRepository
	{
		/// <summary>
		/// Adds registration for a specific handler to a specific event.
		/// </summary>
		/// <typeparam name="THandler">The type of <see cref="IHandler"/> you wish to handle the given <see cref="eventName"/>.</typeparam>
		/// <param name="eventName">The specific <see cref="EventName"/> you wish to be handled by the given <see cref="THandler"/>.</param>
		void AddHandler<THandler>(EventName eventName) where THandler : class, IHandler;
		
		/// <summary>
		/// Tries to get a handler by event name from the repository.
		/// </summary>
		/// <param name="eventName">Event you wish to handle.</param>
		/// <param name="handler">The handler that was in the registry for the given <see cref="eventName"/>.</param>
		/// <returns></returns>
		bool TryGetHandler(string eventName, out IHandler handler);
	}

	[ContractClassFor(typeof(IHandlerRepository))]
	abstract class ContractHandlerRepository : IHandlerRepository
	{
		public void AddHandler<THandler>(EventName eventName) where THandler : class, IHandler
		{
			Contract.Requires(eventName != null);
			throw new System.NotImplementedException();
		}

		public bool TryGetHandler(string eventName, out IHandler handler)
		{
			Contract.Requires(eventName != null);
			throw new System.NotImplementedException();
		}
	}
}