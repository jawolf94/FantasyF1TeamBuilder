using Fantasy.Team;

namespace FantasyF1TeamBuilder;

/// <summary>
/// Provides helper methods to output program results
/// </summary>
internal static class ConsoleHelper
{
	/// <summary>
	/// Prints results for about a predicted team.
	/// </summary>
	internal static void PrintTeam(Team team)
	{
		Console.WriteLine();
		Console.WriteLine($"Total Score: {team.Points} --- Cost: ${team.Cost}");
		Console.WriteLine($"Number of Transfers: {team.NumberOfTransfers} \n");

		Console.WriteLine("**** Constructors ****");
		foreach(var constructor in team.Constructors) 
		{
			Console.WriteLine($"{constructor.Name} | Predicted Points: {constructor.TotalPoints}");
		}

		Console.WriteLine();
		Console.WriteLine("**** Dirvers ****");
		foreach (var driver in team.Drivers)
		{
			var driverName = driver.IsTurboDriver ? $"{driver.Name} (T)" : driver.Name;
			Console.WriteLine($"- {driverName} | Predicted Points: {driver.TotalPoints}");
		}
	}

	/// <summary>
	/// Prompts the user for the their team's current budget.
	/// </summary>
	internal static decimal PromptForBudget()
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
