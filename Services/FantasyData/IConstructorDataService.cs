using Entities;

namespace Services
{
    /// <summary>
    /// Gets raceweek result data for constructors
    /// </summary>
    public interface IConstructorDataService
    {
        /// <summary>
        /// Gets an <see cref="IFantasyData"/> for each constructor.
        /// </summary>
        public Task<List<IFantasyData>> GetConstructorData();
    }
}
