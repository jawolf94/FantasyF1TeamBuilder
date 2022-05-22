using Entities.Drivers;

namespace Services.FantasyData
{
	/// <summary>
	/// Gets race week result data for drivers
	/// </summary>
	public interface IDriverDataService
	{
		/// <summary>
		/// Gets an <see cref="Driver"/> entity for each driver
		/// </summary>
		public Task<List<Driver>> GetDriverData();
	}
}
