using System.Configuration;

namespace Common.Services;

/// <summary>
/// A base class for reading data in CSV format.
/// </summary>
/// <typeparam name="TData">The type of data represented by a row in the csv file.</typeparam>
public abstract class CSVReader<TData>
{
	/// <summary>
	/// Creates a new instance of <see cref="CSVReader{TData}"/>.
	/// </summary>
	/// <param name="filePath">Path to the CSVFile</param>
	/// <exception cref="ConfigurationErrorsException">Thrown if a file path is not specified</exception>
	protected CSVReader(string filePath)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			throw new ConfigurationErrorsException($"A file path was not spceified for {DataCategory} data.");
		}
		FilePath = filePath;
	}

	/// <summary>
	/// The path of the csv file.
	/// </summary>
	protected string FilePath { get; init; }

	/// <summary>
	/// Name of result data obtained from the CSV
	/// </summary>
	protected abstract string DataCategory { get; }

	/// <summary>
	/// Reads result data from a file as <see cref="TData"/>.
	/// </summary>
	protected List<TData> LoadData()
	{
		// ToDo: Check if CSV is structured as expected
		return File.ReadAllLines(FilePath)
			.Skip(1) // Skip header row
			.Select(row => row.Split(','))
			.Select(RowAsTData)
			.ToList();
	}

	/// <summary>
	/// Converts a csv file's row from an array of strings to type TData.
	/// </summary>
	/// <param name="row">A row of data from the csv file. Each position in the array represents a column in the row.</param>
	protected abstract TData RowAsTData(string[] row);
}
