using System;
using System.Reactive.Linq;

namespace RXExamples
{
	public class Application
	{
		private IDisposable _subscribent1;
		private IDisposable _subscribent2;

		public Application()
		{
			var interval = Observable.Interval(TimeSpan.FromSeconds(1));

			_subscribent1 = interval
				.TimeInterval()
				.Subscribe(tick =>
				{
					Console.WriteLine($"Tick 1: {tick}");
				});

			_subscribent2 = interval
				.Sample(TimeSpan.FromSeconds(4))
				.Subscribe(tick =>
				{
					Console.WriteLine($"Tick 2: {tick}");
				});
		}

		public void WaitForKeyPress()
		{
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();

			_subscribent1.Dispose();
			_subscribent2.Dispose();
		}
	}
}
