using Entities;
using Predictors.Predictions;

namespace Predictors
{
    /// <summary>
    /// Applies predictions to fantasy data.
    /// </summary>
    public class PredictionEngine : IPredictionEngine
    {
        private readonly IReadOnlyList<IPrediction> _predictors;

        /// <summary>
        /// Creates a new instance of <see cref="PredictionEngine"/>
        /// </summary>
        public PredictionEngine(IReadOnlyList<IPrediction> predictors)
        {
            _predictors = predictors;
        }

        /// <inheritdoc />
        public double PredictPoints(IFantasyData fantasyData)
        {
            var totalPoints = 0d;
            foreach (var predictor in _predictors)
            {
                if (predictor.CanApply(fantasyData))
                {
                    totalPoints += predictor.PredictedPoints(fantasyData);
                }
            }

            return totalPoints;
        }
    }
}
