using System;
using RXExamples.Domain;
using RXExamples.Observables;

namespace RXExamples.Observers
{
	public class PositionObserver : IObserver<UpdatePosition>
	{
		private Position _position;

		public PositionObserver(PositionObservable positionObservable)
		{
			positionObservable.Subscribe(OnNext);

			_position = Position.Create(Console.WindowWidth / 2, Console.WindowHeight / 2);

			Draw();
		}

		public void OnNext(UpdatePosition updatePosition)
		{
			_position.Update(updatePosition);
			Draw();
		}

		private void Draw()
		{
			Console.Clear();
			Console.SetCursorPosition(_position.Left, _position.Top);
			Console.Write("#");
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}