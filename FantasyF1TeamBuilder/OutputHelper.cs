using Entities;

namespace FantasyF1TeamBuilder
{
	/// <summary>
	/// Provides helper methods to output program results
	/// </summary>
	public static class OutputHelper
	{
		/// <summary>
		/// Prints results for about a predicted team.
		/// </summary>
		public static void PrintTeam(FantasyTeam team)
		{
			Console.WriteLine($"Total Score: {team.Points} --- Cost: ${team.Cost} \n");

			Console.WriteLine("**** Constructor ****");
			Console.WriteLine($"{team.Constructor?.Name} | Predicted Points: {team.Constructor?.Points} \n");

			Console.WriteLine("**** Dirvers ****");
			foreach (var driver in team.Drivers)
			{
				var driverName = driver.IsTurboDriver ? $"{driver.Name} (T)" : driver.Name;
				Console.WriteLine($"- {driverName} | Predicted Points: {driver.Points}");
			}
		}
	}
}
