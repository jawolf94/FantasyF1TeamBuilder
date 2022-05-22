using Configuration;
using Entities.Drivers;
using Entities.FantasyData;
using Services.FantasyData;

namespace Services.FantasyData.CSV
{
	/// <summary>
	/// CSV based service to obtain driver data
	/// </summary>
	public class CSVDriverDataService : CSVServiceBase, IDriverDataService
	{
		/// <summary>
		/// Creates a new instance of <see cref="CSVDriverDataService"/>.
		/// </summary>
		public CSVDriverDataService(ResultSettings config) : base(config.DriverResults)
		{ }

		/// <inheritdoc />
		protected override string ResustDataCategory => "Driver";

		/// <inheritdoc />
		public Task<List<Driver>> GetDriverData()
		{
			var driverData = LoadFantasyData()
				.Select(FantasyData.ToDriver)
				.ToList();

			return Task.FromResult(driverData);
		}
	}
}
