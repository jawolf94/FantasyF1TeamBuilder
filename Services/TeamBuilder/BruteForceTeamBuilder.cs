using Entities;
using Entities.Constructors;
using Entities.Drivers;

namespace Services.TeamBuilder
{
	/// <summary>
	/// Finds the best possible team by evaluating every combination for drivers and constructors.
	/// </summary>
	public class BruteForceTeamBuilder : ITeamBuilder
	{
		/// <inheritdoc />
		public FantasyTeam OptimizeTeam(IReadOnlyList<Driver> drivers, IReadOnlyList<Constructor> constructors, decimal budget)
		{
			var validTeams = new List<FantasyTeam>();
			var loopCount = 0;

			foreach (var driverCombination in PossibleDriverCombinations(drivers))
			{
				foreach(var constructorCombination in PossibleConstructorCombinations(constructors))
				{
					var fantasyTeam = new FantasyTeam(budget);

					fantasyTeam.AddDriversToTeam(driverCombination);
					fantasyTeam.SetTurboDriver(TurboDriverSelector);

					fantasyTeam.AddConstructorsToTeam(constructorCombination);

					if (fantasyTeam.IsValid)
					{
						validTeams.Add(fantasyTeam);
					}

					loopCount++;
				}
			}

			Console.WriteLine($"{loopCount} teams evaluated.");

			return validTeams.MaxBy(t => t.Points) ?? throw new InvalidOperationException("No optimized team could be found");
		}

		private Driver? TurboDriverSelector(IReadOnlyList<Driver> drivers) => 
			drivers.Where(d => d.IsTurboDriverEligible)
				   .MaxBy(d => d.Points);

		private static IEnumerable<Driver[]> PossibleDriverCombinations(IReadOnlyList<Driver> drivers)
		{
			if(drivers.Count < FantasyTeam.NumberOfRequiredDrivers)
			{
				// Not enough drivers - no combinations
				yield break;
			}


			// Create all combinations of drivers of size 5
			for(int d1 = 0; d1 < drivers.Count - 4; d1++)
			{
				for(int d2 = d1 + 1; d2 < drivers.Count - 3; d2++)
				{
					for(int d3 = d2 + 1; d3 < drivers.Count - 2; d3++)
					{
						for(int d4 = d3 + 1; d4 < drivers.Count - 1; d4++)
						{
							for(int d5 = d4 + 1; d5 < drivers.Count; d5++)
							{
								yield return new Driver[]
								{
									drivers[d1],
									drivers[d2],
									drivers[d3],
									drivers[d4],
									drivers[d5]
								};
							}
						}
					}
				}
			}
		}

		private static IEnumerable<Constructor[]> PossibleConstructorCombinations(IReadOnlyList<Constructor> constructors) 
		{
			if (constructors.Count < FantasyTeam.NumberOfRequiredConstructors) 
			{
				// Not enough constructors - no combinations
				yield break;
			}

			// Create all combinations of constuctor pairs
			for (int c1 = 0; c1 < constructors.Count - 1; c1++) 
			{
				for (int c2 = c1 + 1; c2 < constructors.Count; c2++) 
				{
					yield return new Constructor[]
					{
						constructors[c1],
						constructors[c2]
					};
				}
			}
		}
	}
}
