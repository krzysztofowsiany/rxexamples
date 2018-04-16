
using System;

namespace RXExamples.Own
{
	public class OwnObserver : IObserver<string>
	{
		private string _name;

		public OwnObserver(string name)
		{
			_name = name;
		}
		public void OnNext(string value)
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"OwnObserver({_name}): {value}");
		}

		public void OnError(Exception error) { }

		public void OnCompleted() { }
	}
}
