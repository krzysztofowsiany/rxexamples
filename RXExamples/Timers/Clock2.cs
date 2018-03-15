using System;
using System.Diagnostics;

namespace RXExamples.Timers
{
	public class Clock2
	{
		private object _obj;

		public Clock2(IObservable<long> interval, Object obj)
		{
			_obj = obj;

			interval.Subscribe(time =>
			{
				lock (_obj)
				{
					Console.ForegroundColor = ConsoleColor.Black;

					Console.SetCursorPosition(Console.WindowWidth - 12, 2);

					var timeSpan = TimeSpan.FromSeconds(time);
					var timeText = timeSpan.ToString(@"hh\:mm\:ss\:fff");
					Debug.WriteLine(timeText);
					Console.WriteLine(timeText);
					Console.Title = timeText;
				}
			});
		}
	}
}
