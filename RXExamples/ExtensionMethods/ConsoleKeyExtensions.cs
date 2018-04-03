
using System;
using System.Reactive.Linq;
using RXExamples.Observables;

namespace RXExamples.ExtensionMethods
{
	public static class ConsoleKeyExtensions
	{
		public static IObservable<ConsoleKey> MoveUp(this ConsoleKeyObservable consoleKeyObservable)
		{
			return consoleKeyObservable.ObservableConsoleKeyExtensions(ConsoleKey.B);
		}

		public static IObservable<ConsoleKey> MoveLeft(this ConsoleKeyObservable consoleKeyObservable)
		{
			return consoleKeyObservable.ObservableConsoleKeyExtensions(ConsoleKey.PageUp);
		}

		public static IObservable<ConsoleKey> MoveRight(this ConsoleKeyObservable consoleKeyObservable)
		{
			return consoleKeyObservable.ObservableConsoleKeyExtensions(ConsoleKey.PageDown);
		}

		public static IObservable<ConsoleKey> MoveDown(this ConsoleKeyObservable consoleKeyObservable)
		{
			return consoleKeyObservable
				.Where(x => x.Key == ConsoleKey.Escape || x.Key == ConsoleKey.F5)
				.Select(x => x.Key);
		}

		public static IObservable<ConsoleKey> ObservableConsoleKeyExtensions(
			this ConsoleKeyObservable consoleKeyObservable, 
			ConsoleKey key)
		{
			return consoleKeyObservable
				.Where(x => x.Key == key)
				.Select(x => x.Key);
		}
	}
}
