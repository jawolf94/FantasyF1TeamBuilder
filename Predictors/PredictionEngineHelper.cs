using Predictors.Predictions;

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
			};
			return new PredictionEngine(constructorPredictors);
		}
	}
}
