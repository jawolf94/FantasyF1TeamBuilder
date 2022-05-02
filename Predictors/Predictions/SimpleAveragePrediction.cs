using Entities;

namespace Predictors.Predictions
{
    /// <summary>
    /// Predicted number of points earned based on a simple average.
    /// </summary>
    public class SimpleAveragePrediction : IPrediction
    {
        /// <inheritdoc />
        public bool CanApply(IFantasyData fantasyData) => fantasyData.RaceWeekPoints.Count > 0;

        /// <inheritdoc />
        public double PredictedPoints(IFantasyData fantasyData)
        {
            return CanApply(fantasyData)
                ? fantasyData.RaceWeekPoints.Average()
                : 0;
        }
    }
}
