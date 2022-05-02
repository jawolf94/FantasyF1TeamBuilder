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
    /// CSV based service to obtain constructor data
    /// </summary>
    public class CSVConstructorDataService : CSVServiceBase, IConstructorDataService
    {
        private const string ConstructorResultsKey = "constructorResults";

        /// <summary>
        /// Creates a new instance of <see cref="CSVConstructorDataService"/>.
        /// </summary>
        public CSVConstructorDataService(ResultSettings config) : base(config.ConstructorResults) 
        { }

        /// <inheritdoc />
        protected override string ResustDataCategory => "Constructor";

        /// <inheritdoc />
        public Task<List<IFantasyData>> GetConstructorData()
        {
            return Task.FromResult(LoadResultsData());
        }
    }
}
