using System;
using System.Diagnostics;
using RXExamples.Own;

namespace RXExamples.Timers
{
	public class Clock
	{
		private object _obj;

		public Clock(Interval1s interval, Object obj, OwnObserver observer)
		{
			_obj = obj;

			interval.Timer.Subscribe(time =>
			{
				lock (_obj)
				{
					Console.ForegroundColor = ConsoleColor.Black;

					Console.SetCursorPosition(Console.WindowWidth - 8, 0);

					var timeSpan = TimeSpan.FromSeconds(time);
					var timeText = timeSpan.ToString(@"hh\:mm\:ss");
					Debug.WriteLine(timeText);
					Console.WriteLine(timeText);
					Console.Title = timeText;

					observer.OnNext(timeText);
				}
			});
		}
	}
}
