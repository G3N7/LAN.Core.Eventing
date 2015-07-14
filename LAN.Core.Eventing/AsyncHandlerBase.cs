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

		/// <summary>
		/// Will be called upon invocation of the interface's method, to provide easy casting and type safety.
		/// </summary>
		/// <param name="request">A cast version of the <see cref="IHandler.Invoke"/>'s <see cref="RequestBase"/>, that disabiguates <see cref="RequestBase"/> to be specifically <see cref="TReq"/> at compile time.</param>
		/// <param name="principal">A cast version of the <see cref="IHandler.Invoke"/>'s <see cref="IPrincipal"/>, that disabiguates <see cref="IPrincipal"/> to be specifically <see cref="TPrincipal"/> at compile time.</param>
		/// <returns>A task that will execute the logic of this handler</returns>
		protected abstract Task Invoke(TReq request, TPrincipal principal);

		/// <summary>
		/// Will be called upon invocation of the interface's method, to provide easy casting and type safety.
		/// </summary>
		/// <param name="request">A cast version of the <see cref="IHandler.IsAuthorized"/>'s <see cref="RequestBase"/>, that disabiguates <see cref="RequestBase"/> to be specifically <see cref="TReq"/> at compile time.</param>
		/// <param name="principal">A cast version of the <see cref="IHandler.IsAuthorized"/>'s <see cref="IPrincipal"/>, that disabiguates <see cref="IPrincipal"/> to be specifically <see cref="TPrincipal"/> at compile time.</param>
		/// <returns>A task that will result in the user's authorization for this Request.</returns>
		protected abstract Task<bool> IsAuthorized(TReq request, TPrincipal principal);
	}
}