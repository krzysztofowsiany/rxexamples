﻿using System;
using System.Reactive.Linq;

namespace RXExamples.Timers
{
	public class Interval1s
	{
		public IObservable<long> Timer { get; }

		public Interval1s()
		{
			Timer = Observable.Interval(TimeSpan.FromSeconds(1));
		}
	}
}
