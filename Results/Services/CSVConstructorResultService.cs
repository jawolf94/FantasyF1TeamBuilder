using Common.Services;
using Configuration;
using Results.Data;

namespace Results.Services;

/// <summary>
/// Loads constructor result data from a csv file.
/// </summary>
public class CSVConstructorResultService : CSVReader<ConstructorRaceResults>, IConstructorResultService
{
	// Results from the CSV can be cached since result data changes, at most, once per week.
	private Dictionary<string, ConstructorRaceResults>? _constructorResultLookup;

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
		await InitializeResultLookupIfNull();

		return _constructorResultLookup!.Values.ToList();
	}

	/// <inheritdoc />
	public async Task<ConstructorRaceResults?> GetResultsFor(string constructorName)
	{
		await InitializeResultLookupIfNull();

		var hasResult = _constructorResultLookup!.TryGetValue(constructorName, out var result);
		return hasResult ? result : null;
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

	private async Task InitializeResultLookupIfNull() 
	{
		if (_constructorResultLookup is null) 
		{
			var constructorResults = await LoadData();
			_constructorResultLookup = constructorResults.ToDictionary(c => c.Name);
		}
	}

}
