using Entities;

namespace Predictors
{
    /// <summary>
    /// A team built with predicted race results.
    /// </summary>
    public class PredictedFantasyTeam : FantasyTeam<PredictedFantasyScore>
    {
        /// <summary>
        /// Number of points predicted.
        /// </summary>
        public double PredictedPoints => InternalDrivers.Sum(d => d.PredictedPoints) + Constructor.PredictedPoints;

        /// <inheritdoc />
        public override PredictedFantasyScore Constructor { get; set; } = new PredictedFantasyScore();
    }
}
