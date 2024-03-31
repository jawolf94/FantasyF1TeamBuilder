using Common;
using Common.Services;
using Configuration;
using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// CSV based service to obtain driver data
/// </summary>
public class CSVDriverService : CSVReader<Driver>, IFantasyDriverService
{
	// Column indexes for reading CSV files.
	private const int DriverName = 0;
	private const int DriverCost = 1;

	/// <summary>
	/// Creates a new instance of <see cref="CSVDriverService"/>.
	/// </summary>
	public CSVDriverService(FanatsySettings config) : base(config.DriverData)
	{ }

	/// <inheritdoc />
	protected override string DataCategory => "Driver";

	/// <inheritdoc />
	public async Task<List<Driver>> GetDriverData()
	{
		var driverData = await LoadData();
		return driverData;
	}

	/// <inheritdoc />
	protected override Driver RowAsTData(string[] row)
	{
		// Parse name and cost data
		var name = row[DriverName];
		var cost = ParseString.AsDecimal(row[DriverCost], context: nameof(DriverCost));

		return new Driver(name, cost);
	}
}
