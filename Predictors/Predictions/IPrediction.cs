using Entities;

namespace Predictors.Predictions
{
    /// <summary>
    /// A prediction about fantasy data.
    /// </summary>
    public interface IPrediction
    {
        /// <summary>
        /// Returns true if this prediction applies.
        /// </summary>
        public bool CanApply(TeamComponent teamComponent);

        /// <summary>
        /// Predicted number of points gained or lost.
        /// </summary>
        public double PredictedPoints(TeamComponent teamComponent);
    }
}
