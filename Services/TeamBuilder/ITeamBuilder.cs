using Predictors;

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
        PredictedFantasyTeam OptimizeTeam(IReadOnlyList<PredictedFantasyScore> drivers,
            IReadOnlyList<PredictedFantasyScore> constructors, decimal budget);
    }
}
