using System;
using Autofac;

namespace RXExamples
{
	class Program
	{
		static void Main()
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Clear();

			var builder = new ContainerBuilder();
			builder.RegisterModule<AutoFacModule>();
			var container = builder.Build();

			var application = container.Resolve<Application>();
			application.WaitForKeyPress();
		}
	}
}
