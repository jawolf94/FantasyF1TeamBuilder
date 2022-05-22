using Entities;

namespace Predictors.Predictions
{
    /// <summary>
    /// Predicts if streak points will be awarded based on the entity's current steak.
    /// </summary>
    public class SimpleStreakPrediction : IPrediction
    {
        private readonly int _requiredStreak;
        private readonly int _awarededPoints;

        private Func<TeamComponent, int> _steakValueRetriever;

        /// <summary>
        /// Creates a new instance of <see cref="SimpleStreakPrediction"/>
        /// </summary>
        public SimpleStreakPrediction(int requiredStreak, int awardedPoints, Func<TeamComponent, int> streakValueRetriever) 
        {
            _requiredStreak = requiredStreak;
            _awarededPoints = awardedPoints;

            _steakValueRetriever = streakValueRetriever;
        }

        /// <inheritdoc />
        public bool CanApply(TeamComponent teamComponent) => _steakValueRetriever(teamComponent) + 1 == _requiredStreak;

        /// <inheritdoc />
        public double PredictedPoints(TeamComponent teamComponent)
        {
            if (CanApply(teamComponent))
            {
                return _awarededPoints;
            }

            return 0;
        }
    }
}
