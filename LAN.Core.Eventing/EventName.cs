using System;
using System.Collections.Generic;

namespace LAN.Core.Eventing
{
	public class EventName
	{
		private readonly string _name;

		public EventName(Enum eventEnumMember)
		{
			if (eventEnumMember == null) throw new ArgumentNullException("eventEnumMember");
			var enumName = eventEnumMember.GetType().Name;
			if (!enumName.Contains("Events")) throw new ArgumentException(string.Format("Event enums should end with Events as a matter of convention. (was {0})", enumName));
			this._name = enumName.Replace("Events", "") + eventEnumMember;
		}
		
		protected bool Equals(EventName other)
		{
			return other != null && string.Equals(_name, other._name);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == this.GetType() && Equals((EventName)obj);
		}

		public override int GetHashCode()
		{
			return _name != null ? _name.GetHashCode() : 0;
		}

		public static implicit operator string(EventName eventName)
		{
			return eventName != null ? eventName._name : null;
		}

		public static implicit operator EventName(Enum enumValue)
		{
			return new EventName(enumValue);
		}

		public override string ToString()
		{
			return _name;
		}
		
		#region Comparer

		private sealed class NameEqualityComparer : IEqualityComparer<EventName>
		{
			public bool Equals(EventName x, EventName y)
			{
				if (ReferenceEquals(x, y)) return true;
				if (ReferenceEquals(x, null)) return false;
				if (ReferenceEquals(y, null)) return false;
				if (x.GetType() != y.GetType()) return false;
				return string.Equals(x._name, y._name);
			}

			public int GetHashCode(EventName obj)
			{
				return (obj._name != null ? obj._name.GetHashCode() : 0);
			}
		}

		private static readonly IEqualityComparer<EventName> NameComparerInstance = new NameEqualityComparer();

		public static IEqualityComparer<EventName> NameComparer
		{
			get { return NameComparerInstance; }
		}

		#endregion

	}
}