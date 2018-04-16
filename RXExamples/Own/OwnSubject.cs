using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace RXExamples.Own
{
	public class OwnSubject : ISubject<String>
	{
		private IList<IObserver<string>> _observers;
		private OwnObservable _observable;

		public OwnSubject(OwnObservable observable)
		{
			_observers = new List<IObserver<string>>();
			_observable = observable;
		}

		public void Push(string text)
		{
			foreach (var observer in _observers)
			{
				observer.OnNext(text);
			}
		}

		public void OnNext(string value)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine("");
			Console.WriteLine($"OwnSubject (as Observer): {value}");

			_observable.Push("OwnSubject");
		}

		public IDisposable Subscribe(IObserver<string> observer)
		{
			if (!_observers.Contains(observer))
			{
				_observers.Add(observer);
			}

			return new Unsubscribe<string>(_observers, observer);
		}

		public void OnError(Exception error)
		{
		}

		public void OnCompleted()
		{
		}
	}
}
