using Entities.Constructors;

namespace Predictors.PredictedComponents
{
    /// <summary>
    /// A constructor with a predicted score for the next race weekend.
    /// </summary>
    public class PredictedConstructor : Constructor
    {
        private readonly IPredictionEngine _predictionEngine;

        /// <summary>
        /// Initializes a new instance of <see cref="PredictedConstructor"/>
        /// </summary>
        public PredictedConstructor(Constructor constructor, IPredictionEngine predictionEngine)
            : base(constructor.Name, constructor.Cost, constructor.QualifyingStreak, constructor.RaceStreak, constructor.PreviousPointsScored)
        {
            _predictionEngine = predictionEngine;
            BasePoints = _predictionEngine.PredictPoints(constructor);
        }
    }
}
