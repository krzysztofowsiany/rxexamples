using Autofac;

namespace RXExamples
{
	class Program
	{
		static void Main()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule<AutoFacModule>();
			var container = builder.Build();

			var application = container.Resolve<Application>();
			application.WaitForKeyPress();
		}
	}
}
