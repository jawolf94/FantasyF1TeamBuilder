﻿using Common;
using Fantasy.Rules;
using Fantasy.Team;

using static Fantasy.Rules.TeamComposition;

namespace Builders;

/// <summary>
/// Finds the best possible team by evaluating every combination of drivers and constructors.
/// </summary>
public class BruteForceTeamBuilder : ITeamBuilder
{
	/// <inheritdoc />
	public Team BuildOptimizedTeam(IReadOnlyList<Driver> drivers, IReadOnlyList<Constructor> constructors, decimal budget)
	{
		var validTeams = new List<Team>();
		var loopCount = 0;

		foreach (var driverCombination in PossibleDriverCombinations(drivers))
		{
			foreach (var constructorCombination in PossibleConstructorCombinations(constructors))
			{
				var fantasyTeam = new Team(budget);

				AddDriverCopiesToTeam(fantasyTeam, driverCombination);
				AddConstructorCopiesToTeam(fantasyTeam, constructorCombination);
				
				SetHighestScoringEligibleDriverAsTurbo(fantasyTeam);

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

	private static void SetHighestScoringEligibleDriverAsTurbo(Team team)
	{
		var bestEligibleDriver = team.Drivers
			.Where(d => d.IsTurboDriverEligible)
			.MaxBy(d => d.TotalPoints);

		if (bestEligibleDriver is not null)
		{
			bestEligibleDriver.PointsModifier = DriverPointsModifier.Turbo;
		}
	}

	private static void AddDriverCopiesToTeam(Team team, IReadOnlyList<Driver> drivers) 
	{
		var driverCopies = drivers.Select(d => d.CloneAs<Driver>()).ToList();
		team.AddDrivers(driverCopies);
	}

	private static void AddConstructorCopiesToTeam(Team team, IReadOnlyList<Constructor> constructors)
	{
		var constructorCopies = constructors.Select(d => d.CloneAs<Constructor>()).ToList();
		team.AddConstructors(constructorCopies);
	}

	private static IEnumerable<Driver[]> PossibleDriverCombinations(IReadOnlyList<Driver> drivers)
	{
		if (drivers.Count < NumberOfRequiredDrivers)
		{
			// Not enough drivers - no combinations
			yield break;
		}


		// Create all combinations of drivers of size 5
		for (int d1 = 0; d1 < drivers.Count - 4; d1++)
		{
			for (int d2 = d1 + 1; d2 < drivers.Count - 3; d2++)
			{
				for (int d3 = d2 + 1; d3 < drivers.Count - 2; d3++)
				{
					for (int d4 = d3 + 1; d4 < drivers.Count - 1; d4++)
					{
						for (int d5 = d4 + 1; d5 < drivers.Count; d5++)
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
		if (constructors.Count < NumberOfRequiredConstructors)
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