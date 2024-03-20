using Fantasy.Team;

namespace Builders;

/// <summary>
/// Builds an optimal fantasy team based on predicted results
/// </summary>
public interface ITeamBuilder
{
	/// <summary>
	/// Provides the highest scoreing Fantasy F1 Team based on predicted race results.
	/// </summary>
	Team BuildOptimizedTeam(IReadOnlyList<Driver> drivers, IReadOnlyList<Constructor> constructors, decimal budget);
}
