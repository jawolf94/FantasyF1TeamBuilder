using Fantasy.Rules;
using static Fantasy.Rules.DriverPointsModifierHelper;

namespace Fantasy.Team;

/// <summary>
/// Represents a Driver on a fantasy team. 
/// </summary>
public class Driver : TeamComponent
{

	/// <summary>
	/// Initializes a new instance of a <see cref="Driver"/> with no points scored.
	/// </summary>
	public Driver(string name, decimal cost)
		: this(name, cost, 0) { }

	/// <summary>
	/// Initializes a new instance of a <see cref="Driver"/>.
	/// </summary>
	public Driver(string name, decimal cost, double points)
		: base(name, cost)
	{
		BasePoints = points;
	}

	/// <summary>
	/// Points modifier currently applied to the driver.
	/// </summary>
	public DriverPointsModifier PointsModifier { get; set; } = DriverPointsModifier.None;

	/// <summary>
	/// True if the driver is currently set as the turbo driver.
	/// </summary>
	public bool IsTurboDriver => PointsModifier is DriverPointsModifier.Turbo;

	/// <summary>
	/// True if this Driver can be set as a valid turbo driver.
	/// </summary>
	public bool IsTurboDriverEligible => Cost < MaxTurboDriverCost;

	/// <summary>
	/// Creates a deep copy of this Driver instance.
	/// </summary>
	public virtual Driver DeepCopy()
	{
		//ToDo: Make this a helper method.
		var other = new Driver(Name, Cost, BasePoints)
		{
			PointsModifier = PointsModifier
		};

		return other;
	}

	/// <inheritdoc />
	protected override double ApplyPointsModifiers(double points)
	{
		return points * GetAppliedModifier(PointsModifier);
	}

	/// <inheritdoc />
	protected override bool IsEntityValid() => true;
}
