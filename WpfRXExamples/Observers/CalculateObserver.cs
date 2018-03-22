using System;
using System.Diagnostics;
using System.Reactive.Linq;
using WpfRXExamples.Events;
using WpfRXExamples.ExtensionsMethods;
using WpfRXExamples.Observables;

namespace WpfRXExamples.Observers
{
	public class CalculateObserver : IObserver<IEvent>
	{
		private EventObservable _eventBus;

		public CalculateObserver(EventObservable eventBus)
		{
			_eventBus = eventBus;
		}

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		

		public void OnNext(IEvent @event)
		{
			Debug.WriteLine("Observer: " + GetType());

			var calculationStartedEvent = (CalculationStartedEvent)@event;

			var startCalculation = DateTime.UtcNow.Ticks;

			Observable.Start(() => calculationStartedEvent.Data.Fibonacci())
				.Subscribe(result =>
				{
					var calculationTime = DateTime.UtcNow.Ticks - startCalculation;
					_eventBus.Push(CalculatedEvent.Create(result, calculationStartedEvent.Data, calculationTime));
				});
		}
	}
}