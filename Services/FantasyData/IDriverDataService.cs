using Entities;

namespace Services
{
    /// <summary>
    /// Gets raceweek result data for drivers
    /// </summary>
    public interface IDriverDataService
    {
        /// <summary>
        /// Gets an <see cref="IFantasyData"/> for each driver
        /// </summary>
        public Task<List<IFantasyData>> GetDriverData();
    }
}
