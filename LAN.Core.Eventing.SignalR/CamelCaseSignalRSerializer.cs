using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace LAN.Core.Eventing.SignalR
{
	public class CamelCaseSignalRSerializer : ISignalRSerializer
	{
		private readonly JsonSerializerSettings _settings;
		private readonly JsonSerializer _jsonSerializer;

		public CamelCaseSignalRSerializer()
		{
			_settings = new JsonSerializerSettings
			{
				Converters = new JsonConverter[] { new StringEnumConverter() },
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
			};
			_jsonSerializer = JsonSerializer.Create(_settings);
		}

		public JObject Serialize(object obj)
		{
			var jsonStr = JsonConvert.SerializeObject(obj, _settings);
			return JObject.Parse(jsonStr);
		}

		public T Deserialize<T>(string jsonString)
		{
			var jObj = JObject.Parse(jsonString);
			return _jsonSerializer.Deserialize<T>(jObj.CreateReader());
		}

		public T Deserialize<T>(JObject jObj)
		{
			return _jsonSerializer.Deserialize<T>(jObj.CreateReader());
		}
	}
}