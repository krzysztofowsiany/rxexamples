using System;
using System.Diagnostics;
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

		public MainWindow()
		{
			InitializeComponent();
			_random = new Random(DateTime.Now.Millisecond);

			var eventBus = new EventObservable();
			SubscribeToEvents(eventBus);

			Text();
		}

		private void Text()
		{
			Observable.FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
				h => TextBox1.TextChanged += h,
				h => TextBox1.TextChanged -= h)
				.Subscribe(x =>
				{
					var control = x.Sender as TextBox;
					Debug.WriteLine(control.Text);
				}
			);

			Observable.FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
					h => TextBox1.TextChanged += h,
					h => TextBox1.TextChanged -= h)
				.Subscribe(x =>
					{
						var control = x.Sender as TextBox;
						Label1.Content = control.Text;
					}
				);
		}

		private void Click1(EventObservable eventBus)
		{
			Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
					h => FibonacciButton.Click += h,
					h => FibonacciButton.Click -= h)
				.Subscribe(x =>
				{
					var number = _random.Next(40, 100);
					Debug.WriteLine("CalculationStarted for number: " + number);
					eventBus.Push(CalculationStartedEvent.Create(number));
				});
		}

		private void Click2(EventObservable eventBus)
		{
			Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(
				h => ExitButton.Click += h,
				h => ExitButton.Click -= h)
				.Subscribe(x =>
				{
					Debug.WriteLine("ApplicationExitedEvent");
					eventBus.Push(ApplicationExitedEvent.Create(0));
				});
		}

		private void SubscribeToEvents(EventObservable eventBus)
		{
			eventBus
				.Where(x => x is CalculationStartedEvent)
				.Subscribe(new CalculateObserver(eventBus));

			eventBus
				.Where(x => x is CalculatedEvent)
				.Subscribe(x =>
				{
					var calculatedEvent = (CalculatedEvent) x;

					var time = TimeSpan.FromTicks(calculatedEvent.Time);
					Debug.WriteLine($"FibonnaciRx for number: {calculatedEvent.Number} are: {calculatedEvent.Result}, time: {time}");
				});


			SubscribeToApplicationKilledEvent(eventBus);

			Click1(eventBus);

			Click2(eventBus);
		}

		private static void SubscribeToApplicationKilledEvent(EventObservable eventBus)
		{
			var applicationKilledEvent = eventBus
				.Where(x => x is ApplicationExitedEvent);

			applicationKilledEvent
				.Delay(TimeSpan.FromSeconds(5))
				.Subscribe(new ExitObserver());

			applicationKilledEvent
				.Subscribe(new SaveObservable());
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			long number = 45;
			var result = number.Fibonacci();
			Debug.WriteLine($"Fibonnaci for number: {number} are: {result}");
		}
	}
}
