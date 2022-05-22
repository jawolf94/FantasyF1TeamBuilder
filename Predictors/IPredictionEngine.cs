using Entities;

namespace Predictors
{
    /// <summary>
    /// Engine to apply predictions
    /// </summary>
    public interface IPredictionEngine
    {
        /// <summary>
        /// Predicts the total number of points gained/lost based on all applied predictions.
        /// </summary>
        public double PredictPoints(TeamComponent fantasyData);
    }
}
