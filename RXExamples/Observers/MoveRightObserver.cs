using System;
using RXExamples.Domain;
using RXExamples.ExtensionMethods;
using RXExamples.Observables;

namespace RXExamples.Observers
{
	public class MoveRightObserver : IObserver<ConsoleKey>
	{
		private PositionObservable _positionObservable;

		public MoveRightObserver(
			ConsoleKeyObservable observable,
			PositionObservable positionObservable)
		{
			_positionObservable = positionObservable;
			observable
				.MoveRight()
				.Subscribe(this);
		}

		public void OnNext(ConsoleKey value)
		{
			_positionObservable.Publish(UpdatePosition.Create(1, 0));
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}