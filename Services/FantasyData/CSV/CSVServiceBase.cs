using Configuration;
using Entities;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Services.CSV
{
    /// <summary>
    /// Base class for CSV data services.
    /// </summary>
    public abstract class CSVServiceBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="CSVServiceBase"/>.
        /// </summary>
        /// <param name="config">Configuration with CSV file paths.</param>
        /// <param name="configKey">Key used to retrieve configured file path.</param>
        /// <exception cref="ConfigurationErrorsException">Thrown if value is configured for <paramref name="configKey"/>.</exception>
        protected CSVServiceBase(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ConfigurationErrorsException($"A file path was not spceified for {ResustDataCategory} result data.");
            }
            FilePath = filePath;
        }

        /// <summary>
        /// The configured file path.
        /// </summary>
        protected string FilePath { get; init; }

        /// <summary>
        /// Category of result data obtained from the CSV
        /// </summary>
        protected abstract string ResustDataCategory { get; }

        /// <summary>
        /// Reads result data from a file as <see cref="IFantasyData"/>.
        /// </summary>
        protected List<IFantasyData> LoadResultsData()
        {
            // ToDo: Check if CSV is structured as expected
            return File.ReadAllLines(FilePath)
                .Skip(1) // Skip header row
                .Select(row => row.Split(','))
                .Select(AsResultData)
                .ToList();
        }

        private IFantasyData AsResultData(string[] row)
        {
            //ToDo: Add some error handling for CSV formatting

            // Parse name and streak data
            var name = row[0];
            var cost = decimal.Parse(row[1]);
            var qualiSteak = int.Parse(row[2]);
            var raceSteak = int.Parse(row[3]);

            // Parse raceweek results
            var raceWeekScores = new List<int>();
            for (int i = 4; i < row.Length; i++)
            {
                var result = int.Parse(row[i]);
                raceWeekScores.Add(result);

            }

            return new FantasyData(name, cost, raceWeekScores, qualiSteak, raceSteak);
        }

    }
}
