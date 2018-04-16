using System;
using System.Reactive.Linq;
using System.Threading;
using RXExamples.Own;
using RXExamples.Timers;

namespace RXExamples
{
	public class Application
	{
		public Application(
			OwnObservable observable,
			OwnSubject subject,
			Clock clock,
			Interval5s interval5s)
		{
			Console.CursorVisible = false;

			observable.Subscribe(text =>
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"OwnObservable-lambda: {text}");
			});
			observable.Subscribe(new OwnObserver("from OwnObservable"));

			subject.Subscribe(text =>
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"OwnSubject-lambda: {text}");
			});
			subject.Subscribe(new OwnObserver("from OwnSubject"));

			interval5s
				.Timer
				.Select(tick => tick.ToString())
				.Subscribe(subject);
		}

		public void WaitForKeyPress()
		{
			Console.WriteLine("Press space key to exit");

			ConsoleKeyInfo consoleKeyInfo;
			do
			{
				while (!Console.KeyAvailable)
				{
					Thread.Sleep(150);
				}
				consoleKeyInfo = Console.ReadKey(true);
			}
			while (consoleKeyInfo.Key != ConsoleKey.Spacebar);
		}
	}
}
