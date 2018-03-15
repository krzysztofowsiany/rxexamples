using System;
using System.Threading;

namespace RXExamples
{
	public class Application
	{
		public Application()
		{

		}

		public void WaitForKeyPress()
		{
			Console.WriteLine("Press space key to exit");

			ConsoleKeyInfo consoleKeyInfo;
			do
			{
				while (!Console.KeyAvailable)
				{
					Thread.Sleep(150);
				}
				consoleKeyInfo = Console.ReadKey(true);
			}
			while (consoleKeyInfo.Key != ConsoleKey.Spacebar);
		}
	}
}
