using Configuration;
using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CSV
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
        public Task<List<IFantasyData>> GetDriverData()
        {
            return Task.FromResult(LoadResultsData());
        }
    }
}
