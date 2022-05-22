using Entities;
using Entities.Constructors;
using Entities.Drivers;

namespace Services.TeamBuilder
{
    /// <summary>
    /// Builds an optimal fantasy team based on predicted results
    /// </summary>
    public interface ITeamBuilder
    {
        /// <summary>
        /// Optimizes a team using predicted driver and constructor data.
        /// </summary>
        FantasyTeam OptimizeTeam(IReadOnlyList<Driver> drivers,
            IReadOnlyList<Constructor> constructors, decimal budget);
    }
}
