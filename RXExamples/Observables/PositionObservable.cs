using System;
using System.Collections.Generic;
using RXExamples.Domain;

namespace RXExamples.Observables
{
	public class PositionObservable: IObservable<UpdatePosition>
	{
		private IList<IObserver<UpdatePosition>> _observers;

		public PositionObservable()
		{
			_observers = new List<IObserver<UpdatePosition>>();
		}

		public void Publish(UpdatePosition position)
		{
			foreach (var observer in _observers)
			{
				observer.OnNext(position);
			}
		}

		public IDisposable Subscribe(IObserver<UpdatePosition> observer)
		{
			if (!_observers.Contains(observer))
			{
				_observers.Add(observer);
			}

			return new Unsubscribe<UpdatePosition>(_observers, observer);
		}
	}
}
