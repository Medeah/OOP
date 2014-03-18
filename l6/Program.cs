using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace l6
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<int> numbers = new List<int>();
			Random r = new Random();
			int randomNum = 0;
			for (int i = 1; i < 20; i++)
			{
				randomNum = r.Next(0, 100); //random number between 0 and 100
				numbers.Add(randomNum);
			}
			int outer = 3;
			/*
			foreach (var x in numbers.Where ((x) => x % outer == 0)) {
				Console.WriteLine (x);
			}*/

			int MIN = 20, MAX = 40;
			/*foreach (var x in numbers.Where ((x) => MIN < x && x < MAX)) {
				Console.WriteLine (x);
			}*/

			//Console.WriteLine (numbers.Where ((x) => MIN < x && x < MAX).Max ());

			int scalar = 37;

			/*foreach (var x in numbers.Select(x => x * scalar)) {
				Console.WriteLine (x);
			}*/

			/*foreach (var x in numbers.OrderByDescending(x => x)) {
				Console.WriteLine (x);
			}*/

			foreach (var x in numbers
			         .Where ((x) => MIN < x && x < MAX)
			         .Select(x => x * scalar)
			         .OrderByDescending(x => x)) {
				Console.WriteLine (x);
			}

		}
	}
}
