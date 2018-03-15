
using System;
using System.Reactive.Linq;
using Autofac;
using RXExamples.Domain;
using RXExamples.Listeners;
using RXExamples.Observables;
using RXExamples.Own;
using RXExamples.Timers;

namespace RXExamples
{
	public class AutoFacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Application>();

			builder.RegisterInstance(new Object())
				.SingleInstance();

			builder.RegisterType<Clock>();
			builder.RegisterType<Clock2>();

			builder.RegisterInstance(Observable.Interval(TimeSpan.FromMilliseconds(10)))
				.As<IObservable<long>>()
				.SingleInstance();

			builder.RegisterType<Interval1s>()
				.SingleInstance();

			builder.RegisterType<OwnObserver>()
				.SingleInstance();

			builder.RegisterType<OwnObservable>()
				.SingleInstance();

			builder.RegisterType<MoveRightListener>().AsSelf();
			builder.RegisterType<MoveLeftListener>().AsSelf();
			builder.RegisterType<MoveUpListener>().AsSelf();
			builder.RegisterType<MoveDownListener>().AsSelf();
			builder.RegisterType<PositionListener>().AsSelf();

			builder.RegisterType<ConsoleKeyObservable>().SingleInstance();
			builder.RegisterType<PositionObservable>().SingleInstance();
		}
	}
}