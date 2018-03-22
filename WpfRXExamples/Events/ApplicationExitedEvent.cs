namespace WpfRXExamples.Events
{
	public struct ApplicationExitedEvent : IEvent
	{
		public EventType Type { get; set; }

		public int ExitCode { get; set; }

		private ApplicationExitedEvent(int exitCode)
		{
			Type = EventType.ApplicationKilled;
			ExitCode = exitCode;
		}

		public static IEvent Create(int exitCode)
			=> new ApplicationExitedEvent(exitCode);
	}
}
