using System;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LAN.Core.Eventing
{
	public abstract class AsyncHandlerBase<TReq, TPrincipal> : IHandler
		where TReq : RequestBase
		where TPrincipal : IPrincipal
	{
		private static readonly Type ThisType = typeof(TReq);
		public Type GetRequestType()
		{
			return ThisType;
		}

		public Task Invoke(RequestBase req, IPrincipal principal)
		{
			return this.Invoke((TReq)req, (TPrincipal)principal);
		}

		public Task<bool> IsAuthorized(RequestBase req, IPrincipal principal)
		{
			return this.IsAuthorized((TReq)req, (TPrincipal)principal);
		}

		protected abstract Task<bool> IsAuthorized(TReq request, TPrincipal principal);
		protected abstract Task Invoke(TReq request, TPrincipal principal);
	}
}