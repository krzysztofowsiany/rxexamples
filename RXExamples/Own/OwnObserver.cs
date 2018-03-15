
using System;

namespace RXExamples.Own
{
	public class OwnObserver : IObserver<string>
	{
		private IDisposable unsubscriber;

		public OwnObserver(OwnObservable observable)
		{
			observable.Subscribe(this);
		}

		public virtual void Subscribe(IObservable<string> provider)
		{
			unsubscriber = provider.Subscribe(this);
		}

		public virtual void Unsubscribe()
		{
			unsubscriber.Dispose();
		}

		public void OnCompleted()
		{

		}

		public void OnError(Exception error)
		{

		}

		public void OnNext(string value)
		{
		}
	}
}
