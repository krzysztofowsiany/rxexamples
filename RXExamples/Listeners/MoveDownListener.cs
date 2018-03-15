using System;
using System.Reactive.Linq;
using RXExamples.Domain;
using RXExamples.Observables;
using RXExamples.Own;

namespace RXExamples.Listeners
{
	public class MoveDownListener : IObserver<ConsoleKey>
	{
		private PositionObservable _positionObservable;

		public MoveDownListener(
			ConsoleKeyObservable observable,
			PositionObservable positionObservable)
		{
			_positionObservable = positionObservable;
			observable
				.Where(x => x.Key == ConsoleKey.Escape || x.Key == ConsoleKey.F5)
				.Select(x => x.Key)
				.Subscribe(this);
		}

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(ConsoleKey value)
		{
			_positionObservable.Publish(UpdatePosition.Create(0, 1));
		}
	}
}