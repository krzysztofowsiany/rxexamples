using System;
using RXExamples.Domain;
using RXExamples.Observables;
using RXExamples.Timers;

namespace RXExamples.Listeners
{
	public class PositionListener : IObserver<UpdatePosition>
	{
		private Position _position;
		private UpdatePosition _updatePosition;

		public PositionListener(
			PositionObservable positionObservable,
			Interval1s timer)
		{
			positionObservable.Subscribe(OnNext);
			timer.Timer.Subscribe(OnNextDraw);

			_updatePosition = UpdatePosition.Create(0, 0);
			_position = Position.Create(Console.WindowWidth / 2, Console.WindowHeight / 2);

			Draw();
		}

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(UpdatePosition updatePosition)
		{
			_updatePosition = updatePosition;
		}

		public void OnNextDraw(long time)
		{
			Draw();
		}

		private void Draw()
		{
			Console.Clear();
			_position.Update(_updatePosition);
			Console.SetCursorPosition(_position.GetLeft(), _position.GetTop());
			Console.Write("#");
		}
	}
}
