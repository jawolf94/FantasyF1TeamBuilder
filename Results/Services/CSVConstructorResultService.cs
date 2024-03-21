using Common.Services;
using Configuration;
using Results.Data;

namespace Results.Services;

/// <summary>
/// Loads constructor result data from a csv file.
/// </summary>
public class CSVConstructorResultService : CSVReader<ConstructorRaceResults>, IConstructorResultService
{
	protected override string DataCategory => "Driver Statistics";

	public CSVConstructorResultService(StatisticsSettings statisticsSettings)
		: base(statisticsSettings.ConstructorStats) { }

	/// <inheritdoc />
	public Task<List<ConstructorRaceResults>> GetResults()
	{
		var statistics = LoadData();
		return Task.FromResult(statistics);
	}

	/// <inheritdoc />
	protected override ConstructorRaceResults RowAsTData(string[] row)
	{
		string name = row[0];

		var results = row.Skip(1)
			.Select(int.Parse)
			.ToList();

		return new ConstructorRaceResults(name, results);

	}
}
