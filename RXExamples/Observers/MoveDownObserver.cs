using System;
using RXExamples.Domain;
using RXExamples.ExtensionMethods;
using RXExamples.Observables;
namespace RXExamples.Observers
{
	public class MoveDownObserver : IObserver<ConsoleKey>
	{
		private PositionObservable _positionObservable;

		public MoveDownObserver(
			ConsoleKeyObservable consoleKeyObservable,
			PositionObservable positionObservable)
		{
			_positionObservable = positionObservable;
			consoleKeyObservable
				.MoveDown()
				.Subscribe(this);
		}

		public void OnNext(ConsoleKey value)
		{
			_positionObservable.Publish(UpdatePosition.Create(0, 1));
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}