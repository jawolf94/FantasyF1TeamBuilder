using Results.Data;

namespace Analytics.Predictions;

/// <summary>
/// Predicted number of points earned based on a simple average.
/// </summary>
public class SimpleAveragePrediction : IPrediction
{
	/// <inheritdoc />
	public bool CanApply(RaceResults results) => results.PreviousWeekScores.Count > 0;

	/// <inheritdoc />
	public double PredictPoints(RaceResults results)
	{
		return CanApply(results)
			? results.PreviousWeekScores.Average()
			: 0;
	}
}
