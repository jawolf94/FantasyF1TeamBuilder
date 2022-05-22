
using Entities.Drivers;

namespace Predictors.PredictedComponents
{

    /// <summary>
    /// Driver data with a predicted score for the next raceweek.
    /// </summary>
    public class PredictedDriver : Driver
    {
        private readonly IPredictionEngine _predictionEngine;

        /// <summary>
        /// Initializes a new instance of <see cref="PredictedDriver"/>
        /// </summary>
        public PredictedDriver(Driver driver, IPredictionEngine predictionEngine)
            : base(driver.Name, driver.Cost, driver.QualifyingStreak, driver.RaceStreak, driver.PreviousPointsScored)
        {
            _predictionEngine = predictionEngine;
            BasePoints = _predictionEngine.PredictPoints(driver);
        }
    }
}