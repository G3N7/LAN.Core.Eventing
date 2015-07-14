using System;
using System.Diagnostics.Contracts;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(ContractHandler))]
	public interface IHandler
	{
		/// <summary>
		/// Allows you to extract that type of <see cref="RequestBase"/> for which the handler is meant to handle.
		/// </summary>
		/// <returns>The specific implementation of <see cref="RequestBase"/> this handler is meant to handle</returns>
		Type GetRequestType();

		/// <summary>
		/// Invocation of the business logic associated with a given <see cref="RequestBase"/>.
		/// </summary>
		/// <param name="req">The request parameters for this invocation.</param>
		/// <param name="principal">The current principal that initiated this request.</param>
		/// <returns>A task that will execute the logic of this handler</returns>
		Task Invoke(RequestBase req, IPrincipal principal);

		/// <summary>
		/// Will specify if a given user (represented by the <see cref="principal"/>)
		/// </summary>
		/// <param name="req">The request parameters for this invocation.</param>
		/// <param name="principal">The current principal that initiated this request.</param>
		/// <returns>A task that will result in the user's authorization for this Request.</returns>
		Task<bool> IsAuthorized(RequestBase req, IPrincipal principal);
	}

	[ContractClassFor(typeof(IHandler))]
	abstract class ContractHandler : IHandler
	{
		Type IHandler.GetRequestType()
		{
			Contract.Ensures(Contract.Result<Type>() != null);
			throw new NotImplementedException();
		}

		Task IHandler.Invoke(RequestBase req, IPrincipal principal)
		{
			Contract.Requires(req != null);
			Contract.Requires(principal != null);
			throw new NotImplementedException();
		}


		Task<bool> IHandler.IsAuthorized(RequestBase req, IPrincipal principal)
		{
			Contract.Requires(req != null);
			Contract.Requires(principal != null);
			throw new NotImplementedException();
		}
	}
}