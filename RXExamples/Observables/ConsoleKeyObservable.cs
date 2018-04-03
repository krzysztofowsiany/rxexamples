
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace RXExamples.Observables
{
	public class ConsoleKeyObservable : IObservable<ConsoleKeyInfo>
	{
		public IList<IObserver<ConsoleKeyInfo>> _observers;

		public ConsoleKeyObservable()
		{
			_observers = new List<IObserver<ConsoleKeyInfo>>();
		}

		public void StartStream()
		{
			ConsoleKeyInfo consoleKeyInfo;
			var count = 0;
			do
			{
				while (!Console.KeyAvailable)
				{
					Thread.Sleep(150);
					Debug.WriteLine($"delay: {count++}");
				}

				consoleKeyInfo = Console.ReadKey(true);
				Debug.WriteLine($"Read key: {consoleKeyInfo.Key}");

				Publish(consoleKeyInfo);
			}
			while (consoleKeyInfo.Key != ConsoleKey.Spacebar);
		}

		private void Publish(ConsoleKeyInfo consoleKeyInfo)
		{
			foreach (var observer in _observers)
			{
				observer.OnNext(consoleKeyInfo);
			}
		}

		public IDisposable Subscribe(IObserver<ConsoleKeyInfo> observer)
		{
			if (!_observers.Contains(observer))
			{
				_observers.Add(observer);
			}

			return new Unsubscribe<ConsoleKeyInfo>(_observers, observer);
		}
	}
}
