
namespace Entities
{
    /// <summary>
    /// Abstract class representing a Fantasy Team.
    /// </summary>
    public abstract class FantasyTeam<T> where T : IFantasyData
    {
        /// <summary>
        /// Number of drivers per team.
        /// </summary>
        public const int NumberOfRequiredDrivers = 5;

        /// <summary>
        /// Creates a new instance of <see cref="FantasyTeam"/>
        /// </summary>
        protected FantasyTeam() 
        {

        }

        /// <summary>
        /// The team's drivers
        /// </summary>
        public IReadOnlyList<T> Drivers => InternalDrivers;

        /// <summary>
        /// The team's constructor
        /// </summary>
        public abstract T Constructor { get; set; }

        /// <summary>
        /// Total cost of the team.
        /// </summary>
        public decimal Cost => Drivers.Sum(d => d.Cost) + Constructor.Cost;

        /// <summary>
        /// Internal list of drivers for modification
        /// </summary>
        protected List<T> InternalDrivers { get; } = new List<T>();
        
        /// <summary>
        /// Add a new driver to the team
        /// </summary>
        public void AddDriver(T driver)
        {
            if(InternalDrivers.Count >= NumberOfRequiredDrivers)
            {
                throw new ArgumentOutOfRangeException(nameof(driver), $"A team cannot have more than {NumberOfRequiredDrivers} drivers.");
            }

            InternalDrivers.Add(driver);
        }

        /// <summary>
        /// Remove a driver from the team.
        /// </summary>
        public void RemoveDriver(T driver) => InternalDrivers.Remove(driver);
    }
}
