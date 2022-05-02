using Entities;

namespace Predictors {

    /// <summary>
    /// Fantasy data with a predicted score for the next raceweek.
    /// </summary>
    public class PredictedFantasyScore : FantasyData
    {
        /// <summary>
        /// Creates a new instance of <see cref="PredictedFantasyScore"/>.
        /// </summary>
        public PredictedFantasyScore(IFantasyData fantasyData, IPredictionEngine predictionEngine)
            :base(fantasyData)
        {
            PredictedPoints = predictionEngine.PredictPoints(fantasyData);
        }

        /// <summary>
        /// Creates a new instance of<see cref= "PredictedFantasyScore" /> with default values.
        /// </summary>
        public PredictedFantasyScore() : base()
        {
            PredictedPoints = Double.MinValue;
        }

        /// <summary>
        /// Predicted points scored by this driver or constructor.
        /// </summary>
        public double PredictedPoints { get; init; }
    }
}