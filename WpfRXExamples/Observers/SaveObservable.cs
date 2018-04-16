using System;
using System.Diagnostics;
using WpfRXExamples.Events;

namespace WpfRXExamples.Observers
{
	public class SaveObservable : IObserver<ApplicationExitedEvent>
	{
		public void OnNext(ApplicationExitedEvent applicationExitedEvent)
		{
			Debug.WriteLine("Observer: SaveObservable");

			Debug.WriteLine("Save data before exit");
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}