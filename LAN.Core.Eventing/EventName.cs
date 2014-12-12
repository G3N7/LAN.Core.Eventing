using System;

namespace LAN.Core.Eventing
{
	public class EventName
	{
		public EventName(Enum eventEnumMember)
		{
			if (eventEnumMember == null) throw new ArgumentNullException("eventEnumMember");
			var enumName = eventEnumMember.GetType().Name;
			if (!enumName.Contains("Events")) throw new ArgumentException(string.Format("Event enums should end with Events as a matter of convention. (was {0})", enumName));
			this._name = enumName.Replace("Events", "") + eventEnumMember;
		}

		private readonly string _name;

		public static implicit operator string(EventName eventName)
		{
			return eventName == null ? null : eventName._name;
		}

		public static implicit operator EventName(Enum enumValue)
		{
			return new EventName(enumValue);
		}

		public override string ToString()
		{
			return _name;
		}
	}
}