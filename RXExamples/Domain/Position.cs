using System;

namespace RXExamples.Domain
{
	public class Position
	{
		private int _left;
		private int _top;

		private Position(int left, int top)
		{
			_left = left;
			_top = top;
		}
		
		public int GetLeft()
		{
			return _left;
		}

		public int GetTop()
		{
			return _top;
		}

		public void Update(UpdatePosition updatePosition)
		{
			UpdateX(updatePosition.UpdateX);
			UpdateY(updatePosition.UpdateY);
		}

		private void UpdateX(int updateX)
		{
			_left += updateX;

			if (_left > Console.WindowWidth)
				_left = 0;

			if (_left < 0)
				_left = Console.WindowWidth;
		}

		private void UpdateY(int updateY)
		{
			_top += updateY;

			if (_top > Console.WindowHeight)
				_top = 0;

			if (_top < 0)
				_top = Console.WindowHeight;
		}

		public static Position Create(int left = 0, int top = 0) 
			=> new Position(left, top);
	}
}
