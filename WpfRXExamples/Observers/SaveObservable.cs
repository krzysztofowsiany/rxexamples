using System;
using System.Diagnostics;
using WpfRXExamples.Events;

namespace WpfRXExamples.Observers
{
	public class SaveObservable : IObserver<IEvent>
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

			Debug.WriteLine("Save data before exit");
		}
	}
}