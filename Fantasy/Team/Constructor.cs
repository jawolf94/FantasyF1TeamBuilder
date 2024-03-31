namespace Fantasy.Team;

/// <summary>
/// Represents a constructor on a fantasy team.
/// </summary>
public class Constructor : TeamComponent, ICloneable
{
	/// <summary>
	/// Initializes a new instance of <see cref="Constructor"/>
	/// </summary>
	public Constructor(string name, decimal cost, bool isSelected)
	: this(name, cost, 0, isSelected)
	{
	}

	/// <summary>
	/// Initializes a new instance of <see cref="Constructor"/>
	/// </summary>
	public Constructor(string name, decimal cost, double points, bool isSelected)
	: base(name, cost, isSelected)
	{
		// ToDo remove this constructor, points can be publicly set.
		BasePoints = points;
	}

	/// <inheritdoc />
	public object Clone()
	{
		return new Constructor(Name, Cost, BasePoints, IsSelected);
	}

	/// <inheritdoc />
	protected override double ApplyPointsModifiers(double points) => points;

	/// <inheritdoc />
	protected override bool IsEntityValid() => true;

}
