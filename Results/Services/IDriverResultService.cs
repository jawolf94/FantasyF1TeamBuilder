using Results.Data;

namespace Results.Services;

/// <summary>
/// Gets results for Drivers.
/// </summary>
public interface IDriverResultService
{
	/// <summary>
	/// Returns result data for all Drivers.
	/// </summary>
	Task<List<DriverRaceResults>> GetResults();
}
