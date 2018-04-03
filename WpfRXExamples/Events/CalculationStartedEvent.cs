namespace WpfRXExamples.Events
{
	public struct CalculationStartedEvent : IEvent
	{
		public long Data { get; set; }

		private CalculationStartedEvent(long data)
		{
			Data = data;
		}

		public static IEvent Create(long data)
			=> new CalculationStartedEvent(data);
	}
}
