namespace Configuration;

/// <summary>
/// Represents the fantasy settings section of the configuration.
/// </summary>
public class FanatsySettings
{
	/// <summary>
	/// Gets the section name.
	/// </summary>
	public const string Section = "fantasy";

	/// <summary>
	/// Specifies where to get fantasy driver data
	/// </summary>
	public string DriverData { get; set; } = string.Empty;

	/// <summary>
	/// Specifies where to get fantasy constructor data.
	/// </summary>
	public string ConstructorData { get; set; } = string.Empty;
}
