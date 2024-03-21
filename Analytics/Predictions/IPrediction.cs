using Results.Data;

namespace Analytics.Predictions;

/// <summary>
/// A prediction about fantasy data.
/// </summary>
public interface IPrediction
{
	/// <summary>
	/// Returns true if this prediction applies.
	/// </summary>
	bool CanApply(RaceResults teamComponent);

	/// <summary>
	/// Predicted number of points gained or lost.
	/// </summary>
	double PredictPoints(RaceResults teamComponent);
}
