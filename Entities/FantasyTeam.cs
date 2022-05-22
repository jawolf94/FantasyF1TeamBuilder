
using Entities.Constructors;
using Entities.Drivers;

namespace Entities
{
    /// <summary>
    /// Represents a team of drivers and a constructor
    /// </summary>
    public class FantasyTeam : IValidatable
    {
        /// <summary>
        /// Number of drivers allowed per team.
        /// </summary>
        public const int NumberOfRequiredDrivers = 5;

        /// <summary>
        /// Creates a new instance of <see cref="FantasyTeam"/>
        /// </summary>
        public FantasyTeam(decimal budget) 
        {
            Budget = budget;
        }

        /// <summary>
        /// The team's drivers
        /// </summary>
        public IReadOnlyList<Driver> Drivers => InternalDrivers;

        /// <summary>
        /// The team's constructor
        /// </summary>
        public Constructor? Constructor { get; set; }

        /// <summary>
        /// Total points scored by the team.
        /// </summary>
        public double Points => Drivers.Sum(d => d.Points) + ConstructorPoints;

        /// <summary>
        /// Total cost of the team.
        /// </summary>
        public decimal Cost => Drivers.Sum(d => d.Cost) + ConstructorCost;

        /// <inheritdoc />
        public bool IsValid => IsTeamValid();

        /// <summary>
        /// Total budget for this team.
        /// </summary>
        public decimal Budget { get; } = 0;

        /// <summary>
        /// Internal list of drivers for modification
        /// </summary>
        protected List<Driver> InternalDrivers { get; } = new List<Driver>();

        private decimal ConstructorCost => Constructor?.Cost ?? 0;

        private double ConstructorPoints => Constructor?.Points ?? 0;

        /// <summary>
        /// Add a new driver to the team
        /// </summary>
        public void AddDriver(Driver driver)
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
        public void RemoveDriver(Driver driver) => InternalDrivers.Remove(driver);

        /// <summary>
        /// Returns true if this fantasy team is valid.
        /// </summary>
        protected bool IsTeamValid()
        {
            var underBudget = Cost <= Budget;

            var oneTurboDriver = Drivers.Count(d => d.IsTurboDriver) == 1;
            var onOrNoneMegaDriver = Drivers.Count(d => d.IsMegaDriver) <= 1;

            var correctDriverCount = Drivers.Count == 5;
            var hasConstructor = Constructor is not null;

            return underBudget && oneTurboDriver && onOrNoneMegaDriver && correctDriverCount && hasConstructor;
        }
    }
}
