
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

			builder.RegisterType<Clock>();

			builder.RegisterType<Interval1s>()
				.SingleInstance();

			builder.RegisterType<Interval5s>()
				.SingleInstance();

			builder.RegisterType<OwnObserver>();

			builder.RegisterType<OwnObservable>()
				.SingleInstance();

			builder.RegisterType<OwnSubject>()
				.SingleInstance();
		}
	}
}