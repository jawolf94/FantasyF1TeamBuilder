using Fantasy.Rules;
using Fantasy.Team;

using static Common.CloneableExtensions;

namespace Builders;

/// <summary>
/// Fantasy Team extensions used for optimizing teams.
/// </summary>
internal static class TeamExtensions
{
	// ToDo: Move extension functionality to class

	/// <summary>
	/// Adds a list of drivers to the FantasyTeam.
	/// </summary>
	internal static void AddDriversToTeam(this Team team, IReadOnlyList<Driver> drivers)
	{
		foreach (var driver in drivers)
		{
			team.AddDriver(driver.CloneAs<Driver>());
		}
	}

	/// <summary>
	/// Adds a list of drivers to the FantasyTeam.
	/// </summary>
	internal static void AddConstructorsToTeam(this Team team, IReadOnlyList<Constructor> constructors)
	{
		foreach (var constructor in constructors)
		{
			team.AddConstructor(constructor.CloneAs<Constructor>());
		}
	}

	/// <summary>
	/// Sets the FantasyTeam's turbo driver based on the selection criteria.
	/// </summary>
	internal static void SetTurboDriver(this Team team, Func<IReadOnlyList<Driver>, Driver?> selector)
	{
		var bestEligibleDriver = selector(team.Drivers);
		if (bestEligibleDriver is not null)
		{
			bestEligibleDriver.PointsModifier = DriverPointsModifier.Turbo;
		}
	}
}
