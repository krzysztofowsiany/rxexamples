using System;
using Autofac;
using RXExamples.Listeners;

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

			container.Resolve<MoveRightListener>();
			container.Resolve<MoveLeftListener>();
			container.Resolve<MoveUpListener>();
			container.Resolve<MoveDownListener>();
			container.Resolve<PositionListener>();

			var application = container.Resolve<Application>();
			
			application.WaitForKeyPress();
		}
	}
}
