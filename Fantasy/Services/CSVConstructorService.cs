using Common.Services;
using Configuration;
using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// CSV based service to obtain constructor data
/// </summary>
public class CSVConstructorService : CSVReader<Constructor>, IFantasyConstructorService
{
	/// <summary>
	/// Creates a new instance of <see cref="CSVConstructorService"/>.
	/// </summary>
	public CSVConstructorService(FanatsySettings config) : base(config.ConstructorData)
	{ }

	/// <inheritdoc />
	protected override string DataCategory => "Constructor";

	/// <inheritdoc />
	public Task<List<Constructor>> GetConstructorData()
	{
		var constructors = LoadData();
		return Task.FromResult(constructors);
	}

	protected override Constructor RowAsTData(string[] row)
	{
		//ToDo: Add some error handling for CSV formatting

		// Parse name and streak data
		var name = row[0];
		var cost = decimal.Parse(row[1]);

		return new Constructor(name, cost);
	}
}
