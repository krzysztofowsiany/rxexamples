namespace WpfRXExamples.Events
{
	public struct ApplicationExitedEvent : IEvent
	{
		public int ExitCode { get; set; }

		private ApplicationExitedEvent(int exitCode)
		{
			ExitCode = exitCode;
		}

		public static IEvent Create(int exitCode)
			=> new ApplicationExitedEvent(exitCode);
	}
}
