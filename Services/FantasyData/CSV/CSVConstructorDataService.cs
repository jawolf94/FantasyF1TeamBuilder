using Configuration;
using Entities.Constructors;
using Entities.FantasyData;

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
        public Task<List<Constructor>> GetConstructorData()
        {
            var constructors = LoadFantasyData()
                .Select(FantasyData.ToConstructor)
                .ToList();

            return Task.FromResult(constructors);
        }
    }
}
