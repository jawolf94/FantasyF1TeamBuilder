using Microsoft.Extensions.Configuration;

namespace Configuration;


/// <summary>
/// Loads this application's configuration and provides access to configured sections.
/// </summary>
public class ApplicationConfiguration
{
	private readonly Lazy<IConfigurationRoot> _configInstance;

	/// <summary>
	/// Creates a new instance of <see cref="ApplicationConfiguration"/>
	/// </summary>
	public ApplicationConfiguration()
	{
		_configInstance = new Lazy<IConfigurationRoot>(BuildConfiguration);
	}

	/// <summary>
	/// Gets the <see cref="FanatsySettings"/> section from the config.
	/// </summary>
	public FanatsySettings FantasySettings
	{
		get
		{
			var resultSettings = new FanatsySettings();
			Configuration.GetSection(FanatsySettings.Section).Bind(resultSettings);

			return resultSettings;
		}
	}

	/// <summary>
	/// Gets the <see cref="StatisticsSettings"/> section from the config.
	/// </summary>
	public StatisticsSettings StatisticsSettings
	{
		get
		{
			var statisticSettings = new StatisticsSettings();
			Configuration.GetSection(StatisticsSettings.Section).Bind(statisticSettings);

			return statisticSettings;
		}
	}

	/// <summary>
	/// Gets the configration root.
	/// </summary>
	protected IConfigurationRoot Configuration => _configInstance.Value;

	/// <summary>
	/// Creates a configuration builder.
	/// </summary>
	protected virtual IConfigurationBuilder CreateConfigurationBuilder()
	{
		return new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.AddJsonFile("appsettings.dev.json", true);
	}

	/// <summary>
	/// Builds the configuration.
	/// </summary>
	private IConfigurationRoot BuildConfiguration()
	{
		var config = CreateConfigurationBuilder();
		return config.Build();
	}
}
