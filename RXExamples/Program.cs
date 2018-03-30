using System;

namespace RXExamples
{
	class Program
	{
		static void Main()
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Clear();

			var application = new Application();
			application.WaitForKeyPress();
		}
	}
}
