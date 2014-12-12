using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using LAN.Core.DependancyInjection;

namespace LAN.Core.Eventing.SignalR
{
	public class DIHandlerRepository : IHandlerRepository
	{
		private readonly IContainer _container;
		private readonly Dictionary<string, Type> _eventNameToType;
		
		public DIHandlerRepository(IContainer container)
		{
			Contract.Requires(container != null);
			this._container = container;
			if (this._container == null) throw new Exception("You have used a DI Handler repository, before initializing the default container.  You must either provide a container or use an alternate implementation of the handler repository.");
			this._eventNameToType = new Dictionary<string, Type>();
		}

		public void AddHandler<THandler>(EventName eventName) where THandler : class, IHandler
		{
			this._eventNameToType.Add(eventName, typeof(THandler));
			this._container.Bind<THandler, THandler>(true);
		}

		public bool TryGetHandler(EventName eventName, out IHandler handler)
		{
			return this.TryGetHandler(eventName.ToString(), out handler);
		}

		public bool TryGetHandler(string eventName, out IHandler handler)
		{
			Type handlerType;
			var handlerIsRegistered = this._eventNameToType.TryGetValue(eventName, out handlerType);

			if (handlerIsRegistered)
			{
				var unTypedHandler = this._container.GetInstance(handlerType);
				if (unTypedHandler != null)
				{
					handler = (IHandler)unTypedHandler;
					return true;
				}
			}
			handler = null;
			return false;
		}
	}
}