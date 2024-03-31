using Common;
using Common.Services;
using Configuration;
using Results.Data;

namespace Results.Services;

/// <summary>
/// Loads driver result data from a csv file.
/// </summary>
public class CSVDriverResultService : CSVReader<DriverRaceResults>, IDriverResultService
{
	private const int HeaderColumnIndex = 0;

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
		return await LoadData();
	}

	/// <inheritdoc />
	public async Task<DriverRaceResults?> GetResultsFor(string driverName)
	{
		var matchingResults = await LoadData(result => MatchesDriverName(result, driverName));
		return  matchingResults.FirstOrDefault();
	}

	/// <inheritdoc />
	protected override DriverRaceResults RowAsTData(string[] row)
	{
		string name = row[HeaderColumnIndex];

		var results = row.Skip(1)
			.Select(ResultAsInt)
			.ToList();

		return new DriverRaceResults(name, results);
	}

	private static bool MatchesDriverName(DriverRaceResults driverRaceResults, string name)
		=> string.Equals(driverRaceResults.Name, name, StringComparison.OrdinalIgnoreCase);

	private static int ResultAsInt(string result)
		=> ParseString.AsInt(result, context: "DriverResult");
}
