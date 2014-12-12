using System;
using System.Security.Principal;

namespace LAN.Core.Eventing
{
	public abstract class HandlerBase<TReq, TPrincipal> : IHandler
		where TReq : RequestBase
		where TPrincipal : IPrincipal
	{
		private static readonly Type ThisType = typeof(TReq);
		public Type GetRequestType()
		{
			return ThisType;
		}

		public void Invoke(RequestBase req, IPrincipal principal)
		{
			this.Invoke((TReq)req, (TPrincipal)principal);
		}

		public bool IsAuthorized(IPrincipal principal)
		{
			return this.IsAuthorized((TPrincipal)principal);
		}

		protected abstract bool IsAuthorized(TPrincipal principal);
		protected abstract void Invoke(TReq request, TPrincipal principal);
	}

}