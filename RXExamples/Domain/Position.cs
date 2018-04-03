using System;

namespace RXExamples.Domain
{
	public class Position
	{
		public int Left { get; private set; }
		public int Top { get; private set; }

		private Position(int left, int top)
		{
			Left = left;
			Top = top;
		}

		public void Update(UpdatePosition updatePosition)
		{
			Left += updatePosition.UpdateX;
			Top += updatePosition.UpdateY;

			CheckLeft();
			CheckTop();
		}

		private void CheckLeft()
		{
			if (Left > Console.WindowWidth)
				Left = 0;

			if (Left < 0)
				Left = Console.WindowWidth;
		}

		private void CheckTop()
		{
			if (Top > Console.WindowHeight)
				Top = 0;

			if (Top < 0)
				Top = Console.WindowHeight;
		}

		public static Position Create(int left = 0, int top = 0)
			=> new Position(left, top);
	}
}
