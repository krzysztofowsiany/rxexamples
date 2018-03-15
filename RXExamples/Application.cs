using System;
using System.Threading;

namespace RXExamples
{
	public class Application
	{
		private object _obj;

		public Application(Object obj, Clock clock, Clock2 clock2)
		{
			_obj = obj;
			Console.CursorVisible = false;
		}

		public void WaitForKeyPress()
		{
			Console.SetCursorPosition(0, Console.WindowHeight - 1);
			Console.WriteLine("Press space key to exit");

			var counter = 0;

			ConsoleKeyInfo consoleKeyInfo;
			{
				while (!Console.KeyAvailable)
				{
					lock (_obj)
					{
						Console.SetCursorPosition(0, Console.WindowHeight - 2);
						Console.WriteLine(counter++);
					}

					Thread.Sleep(150);
				}
				consoleKeyInfo = Console.ReadKey(true);
			}
			while (consoleKeyInfo.Key != ConsoleKey.Spacebar) ;
		}
	}
}
