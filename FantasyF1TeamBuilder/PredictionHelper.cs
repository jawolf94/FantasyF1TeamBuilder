using Analytics;
using Fantasy.Services;
using Fantasy.Team;
using Results.Services;

namespace FantasyF1TeamBuilder
{
	/// <summary>
	/// Helper class for building predicted results.
	/// </summary>
	internal static class PredictionHelper
	{
		/// <summary>
		/// Builds a list of predicted driver results.
		/// </summary>
		internal static async Task<List<Driver>> BuildDriverPredictions(IFantasyDriverService fantasyDriverService, IDriverResultService driverResultService, IPredictionEngine driverPredictionEngine) 
		{
			var drivers = await fantasyDriverService.GetDriverData();
			foreach (var driver in drivers)
			{
				var driverResults = await driverResultService.GetResultsFor(driver.Name);
				if (driverResults is not null)
				{
					driver.BasePoints = driverPredictionEngine.PredictPoints(driverResults);
				}
			}

			return drivers;
		}

		/// <summary>
		/// Builds a list of predicted constructor results.
		/// </summary>
		internal static async Task<List<Constructor>> BuildConstructorPredictions(IFantasyConstructorService fantasyConstructorService, IConstructorResultService constructorResultService, IPredictionEngine constructorPredictionEngine) 
		{
			var constructors = await fantasyConstructorService.GetConstructorData();
			foreach (var constructor in constructors)
			{
				var constructorResult = await constructorResultService.GetResultsFor(constructor.Name);
				if (constructorResult is not null)
				{
					constructor.BasePoints = constructorPredictionEngine.PredictPoints(constructorResult);
				}
			}

			return constructors;
		}
	}
}
