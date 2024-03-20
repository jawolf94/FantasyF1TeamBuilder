using Analytics.Predictions;

namespace Analytics;

/// <summary>
/// Helper functions for PredictionEngines.
/// </summary>
public static class PredictionEngineBuilder
{
	/// <summary>
	/// Builds a prediction engine for drivers.
	/// </summary>
	public static IPredictionEngine BuildDriverEngine()
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
	public static IPredictionEngine BuildConstructorEngine()
	{
		var constructorPredictors = new List<IPrediction>
		{
			new SimpleAveragePrediction(),
		};
		return new PredictionEngine(constructorPredictors);
	}
}
