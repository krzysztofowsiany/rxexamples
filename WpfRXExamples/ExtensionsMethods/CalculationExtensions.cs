using System.Numerics;
using System.Threading;

namespace WpfRXExamples.ExtensionsMethods
{
	public static class CalculationExtensions
	{
		public static BigInteger Fibonacci(this long n)
		{
			var number = n - 1;
			var fibonacciArray = new BigInteger[number + 1];
			fibonacciArray[0] = 0;
			fibonacciArray[1] = 1;

			for (var i = 2; i <= number; i++)
			{
				fibonacciArray[i] = fibonacciArray[i - 2] + fibonacciArray[i - 1];
				Thread.Sleep(100);
			}

			return fibonacciArray[number];
		}
	}
}
