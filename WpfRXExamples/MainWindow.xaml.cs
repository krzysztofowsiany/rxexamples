using System;
using System.Diagnostics;
using System.Windows;
using WpfRXExamples.ExtensionsMethods;

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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			long number = 45;
			var result = number.Fibonacci();
			Debug.WriteLine($"Fibonnaci for number: {number} are: {result}");
		}
	}
}
