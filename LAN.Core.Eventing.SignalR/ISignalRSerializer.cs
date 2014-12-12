using System.Diagnostics.Contracts;
using Newtonsoft.Json.Linq;

namespace LAN.Core.Eventing.SignalR
{
	[ContractClass(typeof (SignalRSerializerContract))]
	public interface ISignalRSerializer
	{
		JObject Serialize(object obj);
		T Deserialize<T>(string jsonString);
		T Deserialize<T>(JObject jObj);
	}

	[ContractClassFor(typeof (ISignalRSerializer))]
	abstract class SignalRSerializerContract : ISignalRSerializer
	{
		JObject ISignalRSerializer.Serialize(object obj)
		{
			Contract.Requires(obj != null);
			throw new System.NotImplementedException();
		}

		T ISignalRSerializer.Deserialize<T>(string jsonString)
		{
			Contract.Requires(jsonString != null);
			throw new System.NotImplementedException();
		}

		T ISignalRSerializer.Deserialize<T>(JObject jObj)
		{
			Contract.Requires(jObj != null);
			throw new System.NotImplementedException();
		}
	}
}