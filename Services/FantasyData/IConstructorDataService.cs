using Entities.Constructors;

namespace Services
{
    /// <summary>
    /// Gets race week result data for constructors
    /// </summary>
    public interface IConstructorDataService
    {
        /// <summary>
        /// Gets an <see cref="Constructor"/> entity for each constructor.
        /// </summary>
        public Task<List<Constructor>> GetConstructorData();
    }
}
