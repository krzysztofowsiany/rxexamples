using System;
using RXExamples.Observables;

namespace RXExamples
{
	public class Application
	{
		private ConsoleKeyObservable _observable;

		public Application(ConsoleKeyObservable observable)
		{
			_observable = observable;
			Console.CursorVisible = false;
		}

		public void WaitForKeyPress()
		{
			_observable.StartStream();

			Console.SetCursorPosition(0, Console.WindowHeight - 1);
			Console.WriteLine("Press space key to exit");
		}
	}
}
