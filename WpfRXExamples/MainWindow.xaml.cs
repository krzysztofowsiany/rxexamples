using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfRXExamples.Events;
using WpfRXExamples.ExtensionsMethods;
using WpfRXExamples.Observables;
using WpfRXExamples.Observers;

namespace WpfRXExamples
{
	public partial class MainWindow : Window
	{
		private Random _random;
		private List<IDisposable> _subscribents;
		private EventObservable _eventBus;

		public MainWindow()
		{
			InitializeComponent();

			_subscribents = new List<IDisposable>();
			_random = new Random(DateTime.Now.Millisecond);
			_eventBus = new EventObservable();

			//IntervalStream();
			//TextBoxStream();

			//ExitButtonStream();
			//FibonacciButtonStream();
		}

		private void IntervalStream()
		{
			//Make stream
			var stream = Observable
				.Interval(TimeSpan.FromSeconds(1), NewThreadScheduler.Default)
				.Timestamp();

			//Subscriptions
			var subscription1 = stream
				.ObserveOnDispatcher()
				.SubscribeOnDispatcher()
				.Subscribe(tick => Label1.Content = tick);
			_subscribents.Add(subscription1);

			var subscription2 = stream
				.Subscribe(tick => Debug.WriteLine(tick));
			_subscribents.Add(subscription2);
		}

		private void TextBoxStream()
		{
			//Make stream
			var stream = Observable.FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
				@event => TextBox1.TextChanged += @event,
				@event => TextBox1.TextChanged -= @event)
				.Select(x => x.Sender)
				.OfType<TextBox>()
				.Select(textBox => textBox.Text);

			//Subscriptions
			var subscribent1 = stream
				.Subscribe(text => Debug.WriteLine(text));
			_subscribents.Add(subscribent1);

			var subscribent2 = stream
				.Subscribe(text => Label1.Content = text);
			_subscribents.Add(subscribent2);

			var subscribent3 = stream
				.Where(text => text.ToLower().Equals("fibonacci"))
				.Subscribe(text => StartCalculateFibonacciForRandomNumber());
			_subscribents.Add(subscribent3);

			var subscribent4 = stream
				.Where(text => text.ToLower().Equals("exit"))
				.Subscribe(text => SendExitAppEvent());
			_subscribents.Add(subscribent4);
		}

		#region ExitButtonStream
		private void ExitButtonStream()
		{
			//Make stream
			var stream = Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
				@event => ExitButton.Click += @event,
				@event => ExitButton.Click -= @event);

			var subscribent1 = stream
				.Subscribe(x => SendExitAppEvent());
			_subscribents.Add(subscribent1);

			//Subscriptions to event bus
			var applicationKilledEvent = _eventBus
				.Where(x => x is ApplicationExitedEvent)
				.OfType<ApplicationExitedEvent>();

			var subscribent2 = applicationKilledEvent
				.Delay(TimeSpan.FromSeconds(5))
				.Subscribe(new ExitObserver());
			_subscribents.Add(subscribent2);

			var subscribent3 = applicationKilledEvent
				.Subscribe(x => Debug.WriteLine("Save data before exit"));
			_subscribents.Add(subscribent3);
		}

		private void SendExitAppEvent()
		{
			Debug.WriteLine("ApplicationExitedEvent");
			_eventBus.Push(ApplicationExitedEvent.Create(0));
		}
		#endregion

		#region FibonacciButtonStream
		private void FibonacciButtonStream()
		{
			//Make stream
			var stream = Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
				@event => FibonacciButton.Click += @event,
				@event => FibonacciButton.Click -= @event);

			//Subscriptions
			var subscribent1 = stream
				.Subscribe(x => { StartCalculateFibonacciForRandomNumber(); });
			_subscribents.Add(subscribent1);

			//Subscriptions to event bus
			var subscribent2 = _eventBus
				.Where(x => x is CalculationStartedEvent)
				.Subscribe(new CalculateObserver(_eventBus));
			_subscribents.Add(subscribent2);

			var subscribent3 = _eventBus
				.Where(x => x is CalculatedEvent)
				.OfType<CalculatedEvent>()
				.ObserveOnDispatcher()
				.SubscribeOnDispatcher()
				.Subscribe(calculatedEvent =>
				{
					var time = TimeSpan.FromTicks(calculatedEvent.Time);
					var result = $"Fib for: {calculatedEvent.Number} are: {calculatedEvent.Result}, time: {time}";
					Label2.Content = result;
					Debug.WriteLine(result);
				});
			_subscribents.Add(subscribent3);
		}

		private void StartCalculateFibonacciForRandomNumber()
		{
			var number = _random.Next(40, 100);
			Debug.WriteLine($"CalculationStarted for number: {number}");
			_eventBus.Push(CalculationStartedEvent.Create(number));
		}
		#endregion

		private void FibonacciButton_Click(object sender, RoutedEventArgs e)
		{
			var number = 45L;
			var result = number.Fibonacci();
			Debug.WriteLine($"Fibonnaci for number: {number} are: {result}");
		}

		protected override void OnClosed(EventArgs e)
		{
			_subscribents.ForEach(subscribent => subscribent.Dispose());

			base.OnClosed(e);
		}
	}
}
