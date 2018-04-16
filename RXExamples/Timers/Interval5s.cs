using System;
using System.Reactive.Linq;

namespace RXExamples.Timers
{
	public class Interval5s
	{
		public IObservable<long> Timer { get;}

		public Interval5s()
		{
			Timer = Observable.Interval(TimeSpan.FromSeconds(5));
		}
	}
}
