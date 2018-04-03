namespace RXExamples.Domain
{
	public class UpdatePosition
	{
		public int UpdateX { get; }
		public int UpdateY { get;  }

		private UpdatePosition(int updateX, int updateY)
		{
			UpdateX = updateX;
			UpdateY = updateY;
		}
		
		internal static UpdatePosition Create(int updateX, int updateY)
		{
			return new UpdatePosition(updateX, updateY);
		}
	}
}
