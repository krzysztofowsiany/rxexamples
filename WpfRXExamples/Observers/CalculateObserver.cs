using System;
using System.Diagnostics;
using System.Reactive.Linq;
using WpfRXExamples.Events;
using WpfRXExamples.ExtensionsMethods;
using WpfRXExamples.Observables;

namespace WpfRXExamples.Observers
{
	public class CalculateObserver : IObserver<CalculationStartedEvent>
	{
		private EventObservable _eventBus;

		public CalculateObserver(EventObservable eventBus)
		{
			_eventBus = eventBus;
		}

		public void OnNext(CalculationStartedEvent calculationStartedEvent)
		{
			Debug.WriteLine("Observer: " + GetType());

			var startCalculation = DateTime.UtcNow.Ticks;

			Observable.Start(() => calculationStartedEvent.Data.Fibonacci())
				.Subscribe(result =>
				{
					var calculationTime = DateTime.UtcNow.Ticks - startCalculation;
					_eventBus.Push(CalculatedEvent.Create(result, calculationStartedEvent.Data, calculationTime));
				});
		}

		public void OnCompleted() { }

		public void OnError(Exception error) { }
	}
}