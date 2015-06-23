using System;
using System.Diagnostics.Contracts;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LAN.Core.Eventing
{
	[ContractClass(typeof(ContractHandler))]
	public interface IHandler
	{
		Type GetRequestType();
		Task Invoke(RequestBase req, IPrincipal principal);
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