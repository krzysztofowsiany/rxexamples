using System;
using System.Collections.Generic;

namespace RXExamples.Observables
{
	public class Unsubscribe<T> : IDisposable
	{
		private IList<IObserver<T>> _observers;
		private IObserver<T> _observer;

		public Unsubscribe(IList<IObserver<T>> observers, IObserver<T> observer)
		{
			_observers = observers;
			_observer = observer;
		}

		public void Dispose()
		{
			if (_observer != null && _observers.Contains(_observer))
			{
				_observers.Remove(_observer);
			}
		}
	}
}
