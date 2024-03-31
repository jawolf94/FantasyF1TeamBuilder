using Common.Services;
using Configuration;
using Results.Data;

namespace Results.Services;

/// <summary>
/// Loads constructor result data from a csv file.
/// </summary>
public class CSVConstructorResultService : CSVReader<ConstructorRaceResults>, IConstructorResultService
{
	private const int NameColumnIndex = 0;

	/// <summary>
	/// Inititalizes a new isntance of <see cref="CSVConstructorResultService"/>
	/// </summary>
	public CSVConstructorResultService(StatisticsSettings statisticsSettings)
		: base(statisticsSettings.ConstructorStats) { }

	/// <inheritdoc />
	protected override string DataCategory => "Constructor Results";

	/// <inheritdoc />
	public async Task<List<ConstructorRaceResults>> GetAllResults()
	{
		return await LoadData();
	}

	/// <inheritdoc />
	public async Task<ConstructorRaceResults?> GetResultsFor(string constructorName)
	{
		var matchingResults = await LoadData(result => MatchesConstructorName(result, constructorName));
		return matchingResults.FirstOrDefault();
	}

	/// <inheritdoc />
	protected override ConstructorRaceResults RowAsTData(string[] row)
	{
		string name = row[NameColumnIndex];

		var results = row.Skip(1)
			.Select(int.Parse)
			.ToList();

		return new ConstructorRaceResults(name, results);
	}

	private static bool MatchesConstructorName(ConstructorRaceResults constructorResults, string name) 
		=> string.Equals(constructorResults.Name, name, StringComparison.OrdinalIgnoreCase);
}
