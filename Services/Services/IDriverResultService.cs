using Results.Data;

namespace Results.Services;

/// <summary>
/// Gets statistics for F1 race results.
/// </summary>
public interface IDriverResultService
{
	/// <summary>
	/// Returns statistical data from all competitive entrants. 
	/// </summary>
	Task<List<DriverRaceResults>> GetResults();
}
