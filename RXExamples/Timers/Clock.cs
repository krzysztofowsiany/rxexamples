using System;
using System.Diagnostics;
using RXExamples.Own;

namespace RXExamples.Timers
{
	public class Clock : IDisposable
	{
		private IDisposable _subscription;

		public Clock(Interval1s interval, OwnSubject subject)
		{
			_subscription = interval.Timer.Subscribe(time =>
			{
				Console.ForegroundColor = ConsoleColor.White;

				var timeSpan = TimeSpan.FromSeconds(time);
				var timeText = timeSpan.ToString(@"hh\:mm\:ss");

				Console.WriteLine("");
				Console.WriteLine(timeText);

				Console.Title = timeText;

				subject.Push(timeText);
			});
		}

		public void Dispose()
		{
			_subscription?.Dispose();
		}
	}
}
