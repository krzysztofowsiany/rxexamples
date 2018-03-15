using System;
using System.Threading;
using RXExamples.Own;
using RXExamples.Timers;

namespace RXExamples
{
	public class Application
	{
		private object _obj;

		public Application(Object obj, OwnObservable observable, OwnObserver observer, Clock clock)
		{
			_obj = obj;
			Console.CursorVisible = false;
			observable.Subscribe(t =>
			{
				Console.WriteLine(t);
			});
		}

		public void WaitForKeyPress()
		{
			Console.SetCursorPosition(0, Console.WindowHeight - 1);
			Console.WriteLine("Press space key to exit");

			var counter = 0;

			ConsoleKeyInfo consoleKeyInfo;
			do
			{
				while (!Console.KeyAvailable)
				{
					lock (_obj)
					{
						Console.SetCursorPosition(0, Console.WindowHeight - 2);
						Console.WriteLine(counter++);
					}

					Thread.Sleep(150);
				}
				consoleKeyInfo = Console.ReadKey(true);
			}
			while (consoleKeyInfo.Key != ConsoleKey.Spacebar) ;
		}
	}
}
