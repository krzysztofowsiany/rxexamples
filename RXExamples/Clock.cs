using System;
using System.Diagnostics;

namespace RXExamples
{
	public class Clock
	{
		private object _obj;

		public Clock(Interval1s interval, Object obj)
		{
			_obj = obj;

			interval.Timer.Subscribe(time =>
			{
				lock (_obj)
				{
					Console.BackgroundColor = ConsoleColor.Gray;
					Console.ForegroundColor = ConsoleColor.Black;

					Console.SetCursorPosition(Console.WindowWidth - 8, 0);

					var timeSpan = TimeSpan.FromSeconds(time);
					var timeText = timeSpan.ToString(@"hh\:mm\:ss");
					Debug.WriteLine(timeText);
					Console.WriteLine(timeText);
					Console.Title = timeText;
				}
			});
		}
	}
}
