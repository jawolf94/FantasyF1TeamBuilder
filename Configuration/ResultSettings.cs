namespace Configuration
{
	/// <summary>
	/// Represents the result settings section of the configuration.
	/// </summary>
	public class ResultSettings
	{
		/// <summary>
		/// Gets the section name.
		/// </summary>
		public const string Section = "results";

		/// <summary>
		/// Specifies where to get results for driver data.
		/// </summary>
		public string DriverResults { get; set; } = string.Empty;

		/// <summary>
		/// Specifies where to get results for constructor data.
		/// </summary>
		public string ConstructorResults { get; set; } = string.Empty;
	}
}