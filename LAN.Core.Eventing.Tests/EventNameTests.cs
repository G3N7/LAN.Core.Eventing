using NUnit.Framework;

namespace LAN.Core.Eventing.Tests
{
    public class EventNameTests
    {
	    [Test]
		public void Equals_WhenComparingEquivalentValues_ReturnsTrue()
	    {
		    var left = new EventName(SomeTestEvents.TestRequest);
		    var right = new EventName(SomeTestEvents.TestRequest);
			
			bool result = left.Equals(right);
		    Assert.That(result, Is.True);
	    }

	    [Test]
	    public void Equals_WhenComparingNonEquivalentValues_ReturnsFalse()
	    {
			var left = new EventName(SomeTestEvents.TestRequest);
			var right = new EventName(SomeTestEvents.TestResponse);

			bool result = left.Equals(right);
			Assert.That(result, Is.False);
	    }

	    public enum SomeTestEvents
		{
			TestRequest,
			TestResponse
		}
    }
}
