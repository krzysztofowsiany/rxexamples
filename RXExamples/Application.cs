using System;
using System.Threading;
using RXExamples.Own;
using RXExamples.Timers;

namespace RXExamples
{
	public class Application
	{
		private object _obj;

		public Application(OwnObservable observable, OwnObserver observer, Clock clock)
		{
			observable.Subscribe(t =>
			{
				Console.WriteLine(t);
			});
		}

		public void WaitForKeyPress()
		{
			Console.SetCursorPosition(0, Console.WindowHeight - 1);
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
			while (consoleKeyInfo.Key != ConsoleKey.Spacebar) ;
		}
	}
}
