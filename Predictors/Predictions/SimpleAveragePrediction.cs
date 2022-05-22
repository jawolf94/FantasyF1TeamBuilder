using Entities;

namespace Predictors.Predictions
{
	/// <summary>
	/// Predicted number of points earned based on a simple average.
	/// </summary>
	public class SimpleAveragePrediction : IPrediction
	{
		/// <inheritdoc />
		public bool CanApply(TeamComponent teamComponent) => teamComponent.PreviousPointsScored.Count > 0;

		/// <inheritdoc />
		public double PredictedPoints(TeamComponent teamComponent)
		{
			return CanApply(teamComponent)
				? teamComponent.PreviousPointsScored.Average()
				: 0;
		}
	}
}
