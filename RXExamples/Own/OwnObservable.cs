using System;
using System.Collections.Generic;

namespace RXExamples.Own
{
	public class OwnObservable : IObservable<string>
	{
		private IList<IObserver<string>> _observers;

		public OwnObservable()
		{
			_observers = new List<IObserver<string>>();
		}

		public IDisposable Subscribe(IObserver<string> observer)
		{
			if (!_observers.Contains(observer))
			{
				_observers.Add(observer);
			}

			return new Unsubscribe<string>(_observers, observer);
		}
	}
}
