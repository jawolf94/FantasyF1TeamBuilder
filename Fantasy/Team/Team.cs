using Fantasy.Rules;

using static Fantasy.Rules.TeamComposition;
using static Fantasy.Rules.TransferAllowances;

namespace Fantasy.Team;

/// <summary>
/// Represents a team of drivers and constructors
/// </summary>
public class Team : IValidatable
{
	/// <summary>
	/// Creates a new instance of <see cref="Team"/>
	/// </summary>
	public Team(decimal budget)
	{
		Budget = budget;
	}

	/// <summary>
	/// The team's assigned drivers
	/// </summary>
	public IReadOnlyList<Driver> Drivers => InternalDrivers;

	/// <summary>
	/// The team's assigned constructors
	/// </summary>
	public IReadOnlyList<Constructor> Constructors => InternalConstructors;

	/// <summary>
	/// The number of transfers required to create this team.
	/// </summary>
	public int NumberOfTransfers => NumberOfDriverTransfers + NumberOfConstructorTransfers;

	/// <summary>
	/// Total points scored by the team.
	/// </summary>
	public double Points => CalculateTotalPoints();

	/// <summary>
	/// Total cost of the team.
	/// </summary>
	public decimal Cost => CalculateTotalCost();

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

	/// <summary>
	/// Internal list of constructors for modification
	/// </summary>
	protected List<Constructor> InternalConstructors { get; } = new List<Constructor>();

	private int NumberOfDriverTransfers => Drivers.Where(IsTransfer).Count();

	private int NumberOfConstructorTransfers => Constructors.Where(IsTransfer).Count();

	/// <summary>
	/// Add a driver to the team.
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
	/// Adds a list of drivers.
	/// </summary>
	public void AddDrivers(IReadOnlyList<Driver> drivers)
	{
		var totalDriversAfterAdd = InternalDrivers.Count + drivers.Count;
		if(totalDriversAfterAdd > NumberOfRequiredDrivers) 
		{
			throw new ArgumentOutOfRangeException(nameof(drivers), $"A team cannot have more than {NumberOfRequiredDrivers} drivers.");
		}

		foreach (var driver in drivers)
		{
			AddDriver(driver);
		}
	}

	/// <summary>
	/// Add a constructor to the team.
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
	/// Adds a list of constructors.
	/// </summary>
	public void AddConstructors(IReadOnlyList<Constructor> constructors)
	{
		var totalConstructorsAfterAdd = InternalConstructors.Count + constructors.Count;
		if (totalConstructorsAfterAdd > NumberOfRequiredConstructors) 
		{
			throw new ArgumentOutOfRangeException(nameof(constructors), $"A team cannot have more than {NumberOfRequiredConstructors} constructors.");
		}

		foreach (var constructor in constructors)
		{
			AddConstructor(constructor);
		}
	}

	/// <summary>
	/// Remove a driver from the team.
	/// </summary>
	public void RemoveDriver(Driver driver) => InternalDrivers.Remove(driver);

	/// <summary>
	/// Remove a constructor from the team.
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

	private double CalculateTotalPoints() 
	{
		var totalPointsFromDrivers = Drivers.Sum(d => d.TotalPoints);
		var totalPointsFromConstructors = Constructors.Sum(c => c.TotalPoints);
		var pointsLostFromTransfers = CalculateCostOfTransfers(NumberOfTransfers);

		return totalPointsFromDrivers + totalPointsFromConstructors - pointsLostFromTransfers;
	}

	private decimal CalculateTotalCost() 
	{
		var totalCostFromDrivers = Drivers.Sum(d => d.Cost);
		var totalCostFromConstructors = Constructors.Sum(c => c.Cost);

		return totalCostFromDrivers + totalCostFromConstructors;
	}

	private bool IsTransfer(TeamComponent component) => !component.IsSelected;
}
