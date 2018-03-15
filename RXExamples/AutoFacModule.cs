
using Autofac;

namespace RXExamples
{
	public class AutoFacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Application>();
		}
	}
}