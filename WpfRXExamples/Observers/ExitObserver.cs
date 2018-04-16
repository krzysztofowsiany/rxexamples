using System;
using System.Diagnostics;
using WpfRXExamples.Events;

namespace WpfRXExamples.Observers
{
	public class ExitObserver : IObserver<ApplicationExitedEvent>
	{
		public void OnNext(ApplicationExitedEvent applicationExitedEvent)
		{
			Debug.WriteLine("Observer: ExitObserver");

			Environment.Exit(applicationExitedEvent.ExitCode);
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}
