using System;

namespace RXExamples
{
	public class Application
	{
		public Application()
		{
		}

		public void WaitForKeyPress()
		{
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}
	}
}
