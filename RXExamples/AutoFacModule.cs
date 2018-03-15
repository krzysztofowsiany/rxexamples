
using System;
using System.Reactive.Linq;
using Autofac;
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
		}
	}
}