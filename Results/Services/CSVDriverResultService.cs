using Common.Services;
using Configuration;
using Results.Data;

namespace Results.Services;

/// <summary>
/// Loads driver result data from a csv file.
/// </summary>
public class CSVDriverResultService : CSVReader<DriverRaceResults>, IDriverResultService
{
	// Results from the CSV can be cached since result data changes, at most, once per week.
	private Dictionary<string , DriverRaceResults>? _driverResultLookup = null;

	/// <summary>
	/// Initializes a new isntance of <see cref="CSVDriverResultService"/>
	/// </summary>
	public CSVDriverResultService(StatisticsSettings statisticsSettings)
		: base(statisticsSettings.DriverStats) { }

	/// <inheritdoc />
	protected override string DataCategory => "Driver Results";

	/// <inheritdoc />
	public async Task<List<DriverRaceResults>> GetAllResults()
	{
		await InitializeResultLookupIfNull();

		return _driverResultLookup!.Values.ToList();
	}

	/// <inheritdoc />
	public async Task<DriverRaceResults?> GetResultsFor(string driverName)
	{
		await InitializeResultLookupIfNull();

		var hasResult = _driverResultLookup!.TryGetValue(driverName, out DriverRaceResults? result);
		return  hasResult ? result : null;
	}

	/// <inheritdoc />
	protected override DriverRaceResults RowAsTData(string[] row)
	{
		string name = row[0];

		var results = row.Skip(1)
			.Select(int.Parse)
			.ToList();

		return new DriverRaceResults(name, results);
	}

	private async Task InitializeResultLookupIfNull() 
	{
		if (_driverResultLookup is null) 
		{
			var driverResults = await LoadData();
			_driverResultLookup = driverResults.ToDictionary(d => d.Name);
		}
	}
}
