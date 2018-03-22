namespace WpfRXExamples.Events
{
	public struct CalculationStartedEvent : IEvent
	{
		public EventType Type { get; set; }

		public long Data { get; set; }

		private CalculationStartedEvent(long data)
		{
			Type = EventType.ApplicationKilled;
			Data = data;
		}

		public static IEvent Create(long data)
			=> new CalculationStartedEvent(data);
	}
}
