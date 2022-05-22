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
		public FantasyTeam OptimizeTeam(IReadOnlyList<Driver> drivers,
			IReadOnlyList<Constructor> constructors, decimal budget)
		{
			var validTeams = new List<FantasyTeam>();
			var loopCount = 0;

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
								for (int c = 0; c < constructors.Count; c++)
								{
									loopCount++;

									var team = new FantasyTeam(budget);

									team.AddDriver(drivers[d1].DeepCopy());
									team.AddDriver(drivers[d2].DeepCopy());
									team.AddDriver(drivers[d3].DeepCopy());
									team.AddDriver(drivers[d4].DeepCopy());
									team.AddDriver(drivers[d5].DeepCopy());


									team.Constructor = constructors[c];

									if (team.Cost <= budget)
									{
										validTeams.Add(team);
									}
								}
							}
						}
					}
				}
			}

			return validTeams.MaxBy(t => t.Points) ?? throw new InvalidOperationException("No optimized team could be found");
		}
	}
}
