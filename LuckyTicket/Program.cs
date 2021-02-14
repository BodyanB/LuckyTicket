using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace LuckyTicket
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKeyInfo mainkey;
			WriteLine("Press the key to start");
			mainkey = ReadKey();

			while (true)
			{
				Clear();
				WriteLine("Enter your ticket number:");
				ConsoleKeyInfo key;
				var rule = @"[0-9]";
				var sb = new StringBuilder();


				while (true)
				{
					key = ReadKey(true);
					if (sb.Length > 3)
					{
						if (key.Key == ConsoleKey.Enter) break;
					}


					if (Regex.IsMatch(key.KeyChar.ToString(), rule))
					{
						sb.Append(key.KeyChar);
						Write(key.KeyChar);
						if (sb.Length == 8) break;
					}
				}


				if (sb.Length % 2 == 1) sb.Insert(0, "0");


				int[] array = new int[sb.Length];
				string array_str = sb.ToString();
				for (int i = 0; i < sb.Length; i++)
				{
					array[i] = Int32.Parse(array_str[i].ToString());
				}

				WriteLine();

				int sum1 = 0, sum2 = 0;

				for (int i = 0; i < array.Length / 2; i++)
				{
					if (i != (array.Length / 2) - 1)
					{
						sum1 += array[i];
						Write(array[i] + " + ");
					}
					else
					{
						sum1 += array[i];
						WriteLine($"{array[i]} = {sum1}");
					}
				}


				for (int i = array.Length / 2; i < array.Length; i++)
				{
					if (i != array.Length - 1)
					{
						sum2 += array[i];
						Write(array[i] + " + ");
					}
					else
					{
						sum2 += array[i];
						WriteLine($"{array[i]} = {sum2}");
					}
				}


				if (sum1 == sum2)
				{
					WriteLine("Congratulations! Lucky ticket!");
				}
				else
				{
					WriteLine("The ticket is not lucky.");
				}
				WriteLine("Press Escape to exit or any key to continue ...");
				mainkey = ReadKey();
				if (mainkey.Key == ConsoleKey.Escape) break;
			}
		}
	}
}
