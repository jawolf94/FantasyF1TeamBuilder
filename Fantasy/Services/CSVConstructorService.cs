using Common;
using Common.Services;
using Configuration;
using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// CSV based service to obtain constructor data
/// </summary>
public class CSVConstructorService : CSVReader<Constructor>, IFantasyConstructorService
{
	// Column indexes for reading CSV files.
	private const int ConstructorName = 0;
	private const int ConstructorCost = 1;

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
		// Parse name and cost data
		var name = row[ConstructorName];
		var cost = ParseString.AsDecimal(row[ConstructorCost], context: nameof(ConstructorCost));

		return new Constructor(name, cost);
	}
}
