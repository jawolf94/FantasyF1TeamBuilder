using Common.Services;
using Configuration;
using Fantasy.Team;

namespace Fantasy.Services;

/// <summary>
/// CSV based service to obtain driver data
/// </summary>
public class CSVDriverService : CSVReader<Driver>, IFantasyDriverService
{
	/// <summary>
	/// Creates a new instance of <see cref="CSVDriverService"/>.
	/// </summary>
	public CSVDriverService(FanatsySettings config) : base(config.DriverData)
	{ }

	/// <inheritdoc />
	protected override string DataCategory => "Driver";

	/// <inheritdoc />
	public Task<List<Driver>> GetDriverData()
	{
		var driverData = LoadData();
		return Task.FromResult(driverData);
	}

	/// <inheritdoc />
	protected override Driver RowAsTData(string[] row)
	{
		//ToDo: Add some error handling for CSV formatting

		// Parse name and streak data
		var name = row[0];
		var cost = decimal.Parse(row[1]);

		return new Driver(name, cost);
	}
}
