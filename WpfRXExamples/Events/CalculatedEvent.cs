using System.Numerics;

namespace WpfRXExamples.Events
{
	public struct CalculatedEvent : IEvent
	{
		public BigInteger Result { get; set; }
		public long Number { get; set; }
		public long Time { get; set; }

		private CalculatedEvent(BigInteger result, long number, long time)
		{
			Result = result;
			Number = number;
			Time = time;
		}

		public static IEvent Create(BigInteger result, long number, long time)
			=> new CalculatedEvent(result, number, time);
	}
}
