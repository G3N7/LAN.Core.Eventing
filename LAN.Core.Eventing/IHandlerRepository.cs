using System.Diagnostics.Contracts;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(ContractHandlerRepository))]
	public interface IHandlerRepository
	{
		void AddHandler<THandler>(EventName eventName) where THandler : class, IHandler;
		bool TryGetHandler(EventName eventName, out IHandler handler);
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

		public bool TryGetHandler(EventName eventName, out IHandler handler)
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