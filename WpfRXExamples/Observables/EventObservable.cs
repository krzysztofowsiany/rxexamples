using System;
using System.Collections.Generic;
using WpfRXExamples.Events;

namespace WpfRXExamples.Observables
{
	public class EventObservable : IObservable<IEvent>
	{
		private IList<IObserver<IEvent>> _subscribents;

		public EventObservable()
		{
			_subscribents = new List<IObserver<IEvent>>();
		}

		public void Push(IEvent eventType)
		{
			foreach (var subscribent in _subscribents)
			{
				subscribent.OnNext(eventType);
			}
		}

		public IDisposable Subscribe(IObserver<IEvent> observer)
		{
			if (!_subscribents.Contains(observer))
			{
				_subscribents.Add(observer);
			}

			return new Unsubscribe<IEvent>(observer, _subscribents);
		}
	}
}
