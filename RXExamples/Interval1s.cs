using System;
using System.Reactive.Linq;

namespace RXExamples
{
	public class Interval1s
	{
		public IObservable<long> Timer { get; private set; }

		public Interval1s()
		{
			Timer = Observable.Interval(TimeSpan.FromSeconds(1));
		}
	}
}
