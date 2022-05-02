using Microsoft.Extensions.Configuration;

namespace Configuration
{
  
    /// <summary>
    /// Loads this application configuration and provides access to configured sections.
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
        /// Gets the ResultSettings section from the config.
        /// </summary>
        public ResultSettings ResultSettings 
        {
            get
            {
                var resultSettings = new ResultSettings();
                Configuration.GetSection(ResultSettings.Section).Bind(resultSettings);

                return resultSettings;
            }
        }

        /// <summary>
        /// Gets the configration root.
        /// </summary>
        protected IConfigurationRoot Configuration => _configInstance.Value;

        /// <summary>
        /// Creates a configuration builder.
        /// </summary>
        protected virtual IConfigurationBuilder GetConfigurationBuilder()
        {
            return  new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.dev.json", true);
        }

        /// <summary>
        /// Builds the configuration.
        /// </summary>
        private IConfigurationRoot BuildConfiguration()
        {
            var config = GetConfigurationBuilder();
            return config.Build();
        }
    }
}
