using Common.Services;
using Configuration;
using Results.Data;

namespace Results.Services;

/// <summary>
/// Loads statistical data from a csv file.
/// </summary>
public class CSVDriverResultService : CSVReader<DriverRaceResults>, IDriverResultService
{
	protected override string DataCategory => "Driver Statistics";

	public CSVDriverResultService(StatisticsSettings statisticsSettings)
		: base(statisticsSettings.DriverStats) { }

	/// <inheritdoc />
	public Task<List<DriverRaceResults>> GetResults()
	{
		var statistics = LoadData();
		return Task.FromResult(statistics);
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
}
