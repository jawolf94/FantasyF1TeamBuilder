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

        private Func<IFantasyData, int> _steakValueRetriever;

        /// <summary>
        /// Creates a new instance of <see cref="SimpleStreakPrediction"/>
        /// </summary>
        public SimpleStreakPrediction(int requiredStreak, int awardedPoints, Func<IFantasyData, int> streakValueRetriever) 
        {
            _requiredStreak = requiredStreak;
            _awarededPoints = awardedPoints;

            _steakValueRetriever = streakValueRetriever;
        }

        /// <inheritdoc />
        public bool CanApply(IFantasyData fantasyData) => _steakValueRetriever(fantasyData) + 1 == _requiredStreak;

        /// <inheritdoc />
        public double PredictedPoints(IFantasyData fantasyData)
        {
            if (CanApply(fantasyData))
            {
                return _awarededPoints;
            }

            return 0;
        }
    }
}
