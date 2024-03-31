using Common.Services;
using Configuration;
using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// CSV based service to obtain constructor data
/// </summary>
public class CSVConstructorService : CSVReader<Constructor>, IFantasyConstructorService
{
	private const int NameColumnIndex = 0;
	private const int CostColumnIndex = 1;

	/// <summary>
	/// Creates a new instance of <see cref="CSVConstructorService"/>.
	/// </summary>
	public CSVConstructorService(FanatsySettings config) : base(config.ConstructorData)
	{ }

	/// <inheritdoc />
	protected override string DataCategory => "Constructor";

	/// <inheritdoc />
	public async Task<List<Constructor>> GetConstructorData()
	{
		var constructors = await LoadData();
		return constructors;
	}

	protected override Constructor RowAsTData(string[] row)
	{
		//ToDo: Add some error handling for CSV formatting

		// Parse name and cost data
		var name = row[NameColumnIndex];
		var cost = decimal.Parse(row[CostColumnIndex]);

		return new Constructor(name, cost);
	}
}
