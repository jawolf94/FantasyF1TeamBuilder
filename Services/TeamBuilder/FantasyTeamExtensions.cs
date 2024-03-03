using Entities;
using Entities.Constructors;
using Entities.Drivers;

namespace Services.TeamBuilder
{
	/// <summary>
	/// Fantasy Team extensions used for optimizing teams.
	/// </summary>
	internal static class FantasyTeamExtensions
	{
		/// <summary>
		/// Adds a list of drivers to the FantasyTeam.
		/// </summary>
		internal static void AddDriversToTeam(this FantasyTeam team, IReadOnlyList<Driver> drivers)
		{
			foreach(var driver in drivers)
			{
				team.AddDriver(driver.DeepCopy());
			}
		}

		/// <summary>
		/// Adds a list of drivers to the FantasyTeam.
		/// </summary>
		internal static void AddConstructorsToTeam(this FantasyTeam team, IReadOnlyList<Constructor> constructors)
		{
			foreach (var constructor in constructors)
			{
				team.AddConstructor(constructor.DeepCopy());
			}
		}

		/// <summary>
		/// Sets the FantasyTeam's turbo driver based on the selection criteria.
		/// </summary>
		internal static void SetTurboDriver(this FantasyTeam team, Func<IReadOnlyList<Driver>, Driver?> selector)
		{
			var bestEligibleDriver = selector(team.Drivers);
			if (bestEligibleDriver is not null)
			{
				bestEligibleDriver.PointsModifier = DriverPointsModifier.Turbo;
			}
		}
	}
}
