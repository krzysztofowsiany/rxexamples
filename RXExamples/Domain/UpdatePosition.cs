namespace RXExamples.Domain
{
	public class UpdatePosition
	{
		private int _updateX;
		private int _updateY;

		public int UpdateX => _updateX;
		public int UpdateY => _updateY;

		private UpdatePosition(int updateX, int updateY)
		{
			_updateX = updateX;
			_updateY = updateY;
		}
		
		internal static UpdatePosition Create(int updateX, int updateY)
		{
			return new UpdatePosition(updateX, updateY);
		}
	}
}
