using System;
using RXExamples.Domain;
using RXExamples.ExtensionMethods;
using RXExamples.Observables;

namespace RXExamples.Observers
{
	public class MoveLeftObserver : IObserver<ConsoleKey>
	{
		private PositionObservable _positionObservable;

		public MoveLeftObserver(
			ConsoleKeyObservable consoleKeyObservable,
			PositionObservable positionObservable)
		{
			_positionObservable = positionObservable;
			consoleKeyObservable
				.MoveLeft()
				.Subscribe(this);
		}

		public void OnNext(ConsoleKey value)
		{
			_positionObservable.Publish(UpdatePosition.Create(-1, 0));
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}