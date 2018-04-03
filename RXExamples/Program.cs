using System;
using Autofac;
using RXExamples.Observers;

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

			container.Resolve<MoveRightObserver>();
			container.Resolve<MoveLeftObserver>();
			container.Resolve<MoveUpObserver>();
			container.Resolve<MoveDownObserver>();
			container.Resolve<PositionObserver>();

			var application = container.Resolve<Application>();
			
			application.WaitForKeyPress();
		}
	}
}
