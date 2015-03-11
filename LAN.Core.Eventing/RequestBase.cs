namespace LAN.Core.Eventing
{
	public abstract class RequestBase
	{
		public IConnectionContext ConnectionContext { get; set; }
	}
}