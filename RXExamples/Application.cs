using System;
using RXExamples.Observables;

namespace RXExamples
{
	public class Application
	{
		private ConsoleKeyObservable _consoleKeyObservable;

		public Application(ConsoleKeyObservable consoleKeyObservable)
		{
			_consoleKeyObservable = consoleKeyObservable;
			Console.CursorVisible = false;
		}

		public void WaitForKeyPress()
		{
			_consoleKeyObservable.StartStream();

			Console.SetCursorPosition(0, Console.WindowHeight - 1);
			Console.WriteLine("Press space key to exit");
		}
	}
}
