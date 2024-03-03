using Entities;

namespace FantasyF1TeamBuilder
{
	/// <summary>
	/// Provides helper methods to output program results
	/// </summary>
	public static class ConsoleHelper
	{
		/// <summary>
		/// Prints results for about a predicted team.
		/// </summary>
		public static void PrintTeam(FantasyTeam team)
		{
			Console.WriteLine($"Total Score: {team.Points} --- Cost: ${team.Cost} \n");

			Console.WriteLine("**** Constructors ****");
			foreach(var constructor in team.Constructors) 
			{
				Console.WriteLine($"{constructor.Name} | Predicted Points: {constructor.Points}");
			}

			Console.WriteLine();
			Console.WriteLine("**** Dirvers ****");
			foreach (var driver in team.Drivers)
			{
				var driverName = driver.IsTurboDriver ? $"{driver.Name} (T)" : driver.Name;
				Console.WriteLine($"- {driverName} | Predicted Points: {driver.Points}");
			}
		}

		/// <summary>
		/// Prompts the user for the their team's current budget.
		/// </summary>
		public static decimal PromptForBudget()
		{
			Console.WriteLine("Please enter your team's budget cap then press ENTER.");

			var remainingAttempts = 3;
			while(remainingAttempts-- > 0)
			{
				var userValue = Console.ReadLine();
				if(userValue is not null)
				{
					var isSuccess = Decimal.TryParse(userValue, out var keyedDecimal);
					if(isSuccess && keyedDecimal >= 0)
					{
						return keyedDecimal;
					}
					else
					{
						Console.WriteLine("Please enter a valid budget.");
					}
				}
				else
				{
					Console.WriteLine("Please enter your team's budget.");
				}
			}

			throw new InvalidOperationException("No valid budget provided.");
		}
	}
}
