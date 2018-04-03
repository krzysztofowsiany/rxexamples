using System;
using RXExamples.Domain;
using RXExamples.ExtensionMethods;
using RXExamples.Observables;

namespace RXExamples.Observers
{
	public class MoveUpObserver : IObserver<ConsoleKey>
	{
		private PositionObservable _positionObservable;

		public MoveUpObserver(
			ConsoleKeyObservable observable,
			PositionObservable positionObservable)
		{
			_positionObservable = positionObservable;
			observable
				.MoveUp()
				.Subscribe(this);
		}

		public void OnNext(ConsoleKey value)
		{
			_positionObservable.Publish(UpdatePosition.Create(0, -1));
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}