using Predictors.Predictions;
using static Entities.StreakRules;

namespace Predictors
{
    /// <summary>
    /// Helper functions for PredictionEngines.
    /// </summary>
    public static class PredictionEngineHelper
    {
        /// <summary>
        /// Builds a prediction engine for drivers.
        /// </summary>
        public static IPredictionEngine BuildDriverPredictionEngine() 
        {
            var driverPredictors = new List<IPrediction>
            {
                new SimpleAveragePrediction(),
                new SimpleStreakPrediction(DriverQualifyingStreakRequirement, QualifyingStreakAwardedPoints, f => f.QualifyingStreak),
                new SimpleStreakPrediction(DriverRaceStreakRequirement, RaceStreakAwardedPoints, f => f.RaceStreak)
            };

           return new PredictionEngine(driverPredictors);
        }

        /// <summary>
        /// Builds a prediction engine for constructors.
        /// </summary>
        public static IPredictionEngine BuildConstructorPredictionEngine()
        {
            var constructorPredictors = new List<IPrediction>
            {
                new SimpleAveragePrediction(),
                new SimpleStreakPrediction(ConstructorQualifyingStreakRequirement, QualifyingStreakAwardedPoints, f => f.QualifyingStreak),
                new SimpleStreakPrediction(ConstructorRaceStreakRequirement, RaceStreakAwardedPoints, f => f.RaceStreak)
            };
            return new PredictionEngine(constructorPredictors);
        }
    }
}
