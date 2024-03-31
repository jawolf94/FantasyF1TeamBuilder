using Fantasy.Rules;
using static Fantasy.Rules.DriverPointsModifierHelper;

namespace Fantasy.Team;

/// <summary>
/// Represents a Driver on a fantasy team. 
/// </summary>
public class Driver : TeamComponent, ICloneable
{

	/// <summary>
	/// Initializes a new instance of a <see cref="Driver"/> with no points scored.
	/// </summary>
	public Driver(string name, decimal cost, bool isSelected)
		: this(name, cost, 0, isSelected) { }

	/// <summary>
	/// Initializes a new instance of a <see cref="Driver"/>.
	/// </summary>
	public Driver(string name, decimal cost, double points, bool isSelected)
		: base(name, cost, isSelected)
	{
		// ToDo remove this constructor, points can be publicly set.
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

	/// <inheritdoc />
	public object Clone()
	{
		return new Driver(Name, Cost, BasePoints, IsSelected)
		{
			PointsModifier = PointsModifier
		};
	}

	/// <inheritdoc />
	protected override double ApplyPointsModifiers(double points)
	{
		return points * GetAppliedModifier(PointsModifier);
	}

	/// <inheritdoc />
	protected override bool IsEntityValid() => true;
}
