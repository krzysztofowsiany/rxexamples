using Autofac;
using RXExamples.Observers;
using RXExamples.Observables;

namespace RXExamples
{
	public class AutoFacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Application>();

			builder.RegisterType<MoveRightObserver>().AsSelf();
			builder.RegisterType<MoveLeftObserver>().AsSelf();
			builder.RegisterType<MoveUpObserver>().AsSelf();
			builder.RegisterType<MoveDownObserver>().AsSelf();
			builder.RegisterType<PositionObserver>().AsSelf();

			builder.RegisterType<ConsoleKeyObservable>().SingleInstance();
			builder.RegisterType<PositionObservable>().SingleInstance();
		}
	}
}