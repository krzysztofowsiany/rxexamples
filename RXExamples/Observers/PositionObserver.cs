using System;
using System.Collections.Generic;
using RXExamples.Domain;
using RXExamples.Observables;

namespace RXExamples.Observers
{
	public class PositionObserver : IObserver<UpdatePosition>
	{
		private Position _position;
		private byte frame;
		private List<string[]> frames;

		public PositionObserver(PositionObservable positionObservable)
		{
			frame = 0;

			InitializeFrames();

			positionObservable.Subscribe(OnNext);

			_position = Position.Create(Console.WindowWidth / 2, Console.WindowHeight / 2);

			Draw();
		}

		private void InitializeFrames()
		{
			frames = new List<string[]>
			{
				new[] {"\\o/", " |", "/ \\"},
				new[] {" o", "/|\\", " |"},
				new[] {"_o_", " |", "/ \\"},
				new[] {"_o", " |\\", " |"}
			};
		}

		public void OnNext(UpdatePosition updatePosition)
		{
			_position.Update(updatePosition);
			Draw();
			UpdateFrame();
		}

		private void UpdateFrame()
		{
			frame++;
			if (frame >= frames.Count)
			{
				frame = 0;
			}
		}

		private void Draw()
		{
			Console.Clear();
			DrawFrame(frames[frame]);
		}

		private void DrawFrame(string[] array)
		{
			for (var i = 0; i < 3; i++)
			{
				Console.SetCursorPosition(_position.Left, _position.Top + i);
				Console.Write(array[i]);
			}
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}