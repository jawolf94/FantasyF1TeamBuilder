using Entities;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Services.CSV
{
    /// <summary>
    /// Service which loads IResultData from a CSV file.
    /// </summary>
    public class FantasyDataService : IFantasyDataService
    {
        private readonly IConstructorDataService _constructorDataService;
        private readonly IDriverDataService _driverDataService;

        /// <summary>
        /// Creates a new instance of <see cref="FantasyDataService"/>.
        /// </summary>
        public FantasyDataService(IConstructorDataService constructorDataService, IDriverDataService driverDataService) 
        {
            _constructorDataService = constructorDataService;
            _driverDataService = driverDataService;
        }

        /// <inheritdoc />
        public Task<List<IFantasyData>> GetConstructorData()
        {
            return _constructorDataService.GetConstructorData();
        }

        /// <inheritdoc />
        public Task<List<IFantasyData>> GetDriverData()
        {
            return _driverDataService.GetDriverData();
        }
    }
}
