namespace Configuration
{
	/// <summary>
	/// Represents the statistics settings section of the configuration.
	/// </summary>
	public class StatisticsSettings
	{
		/// <summary>
		/// Gets the section name.
		/// </summary>
		public const string Section = "statistics";

		/// <summary>
		/// Specifies where to get statistics for drivers.
		/// </summary>
		public string DriverStats { get; set; } = string.Empty;

		/// <summary>
		/// Specifies where to get statistics for constructors.
		/// </summary>
		public string ConstructorStats { get; set; } = string.Empty;
	}
}