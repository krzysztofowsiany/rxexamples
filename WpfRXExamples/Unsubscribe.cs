using System;
using System.Collections.Generic;

namespace WpfRXExamples
{
	internal class Unsubscribe<T> : IDisposable
	{
		private readonly IObserver<T> _observer;
		private readonly IList<IObserver<T>> _subscribents;

		public Unsubscribe(IObserver<T> observer, IList<IObserver<T>> subscribents)
		{
			_observer = observer;
			_subscribents = subscribents;
		}

		public void Dispose()
		{
			_subscribents.Remove(_observer);
		}
	}
}
