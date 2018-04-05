using System;
using System.Diagnostics;
using System.Windows;
using WpfRXExamples.ExtensionsMethods;
using System.Reactive;

namespace WpfRXExamples
{
	public partial class MainWindow : Window
	{
		private Random _random;

		public MainWindow()
		{
			InitializeComponent();
			_random = new Random(DateTime.Now.Millisecond);

		}

		private void FibonacciButton_Click(object sender, RoutedEventArgs e)
		{
			var number = 45L;
			var result = number.Fibonacci();
			Debug.WriteLine($"Fibonnaci for number: {number} are: {result}");
		}
	}
}
