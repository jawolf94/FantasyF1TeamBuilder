
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
		/// Number of drivers allowed per team.
		/// </summary>
		public const int NumberOfRequiredConstructors = 2;

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

		public IReadOnlyList<Constructor> Constructors => InternalConstructors;

		/// <summary>
		/// Total points scored by the team.
		/// </summary>
		public double Points => TotalDriverPoints + TotalConstructorPoints;

		/// <summary>
		/// Total cost of the team.
		/// </summary>
		public decimal Cost => TotalDriverCost + TotalConstructorCost;

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

		protected List<Constructor> InternalConstructors { get; } = new List<Constructor>();

		private double TotalDriverPoints => Drivers.Sum(d => d.Points);

		private decimal TotalDriverCost => Drivers.Sum(d => d.Cost);


		private double TotalConstructorPoints => InternalConstructors.Sum(c => c.Points);

		private decimal TotalConstructorCost => InternalConstructors.Sum(c => c.Cost);


		/// <summary>
		/// Add a new driver to the team
		/// </summary>
		public void AddDriver(Driver driver)
		{
			if (InternalDrivers.Count >= NumberOfRequiredDrivers)
			{
				throw new ArgumentOutOfRangeException(nameof(driver), $"A team cannot have more than {NumberOfRequiredDrivers} drivers.");
			}

			InternalDrivers.Add(driver);
		}

		/// <summary>
		/// Add a new driver to the team
		/// </summary>
		public void AddConstructor(Constructor constructor)
		{
			if (InternalConstructors.Count >= NumberOfRequiredConstructors)
			{
				throw new ArgumentOutOfRangeException(nameof(constructor), $"A team cannot have more than {NumberOfRequiredConstructors} constructors.");
			}

			InternalConstructors.Add(constructor);
		}

		/// <summary>
		/// Remove a driver from the team.
		/// </summary>
		public void RemoveDriver(Driver driver) => InternalDrivers.Remove(driver);

		/// <summary>
		/// Remove a driver from the team.
		/// </summary>
		public void RemoveConstructor(Constructor constructor) => InternalConstructors.Remove(constructor);

		/// <summary>
		/// Returns true if this fantasy team is valid.
		/// </summary>
		protected bool IsTeamValid()
		{
			var underBudget = Cost <= Budget;

			var oneTurboDriver = Drivers.Count(d => d.IsTurboDriver) == 1;

			var correctDriverCount = Drivers.Count == NumberOfRequiredDrivers;
			var correctConstructorCount = Constructors.Count == NumberOfRequiredConstructors;

			return underBudget && oneTurboDriver && correctDriverCount && correctConstructorCount;
		}
	}
}
