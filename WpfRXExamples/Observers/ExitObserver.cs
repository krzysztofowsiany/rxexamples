using System;
using System.Diagnostics;
using WpfRXExamples.Events;

namespace WpfRXExamples.Observers
{
	public class ExitObserver : IObserver<IEvent>
	{
		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(IEvent @event)
		{
			Debug.WriteLine("Observer: " + GetType());

			var applicationExitedEvent = (ApplicationExitedEvent)@event;

			Environment.Exit(applicationExitedEvent.ExitCode);
		}
	}
}
