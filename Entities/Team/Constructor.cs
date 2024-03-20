namespace Fantasy.Team;

/// <summary>
/// Represents a constructor on a fantasy team.
/// </summary>
public class Constructor : TeamComponent
{
	/// <summary>
	/// Initializes a new instance of <see cref="Constructor"/>
	/// </summary>
	public Constructor(string name, decimal cost)
	: this(name, cost, 0)
	{
	}

	/// <summary>
	/// Initializes a new instance of <see cref="Constructor"/>
	/// </summary>
	public Constructor(string name, decimal cost, double points)
	: base(name, cost)
	{
		BasePoints = points;
	}

	/// <summary>
	/// Creates a copy of this Constructor.
	/// </summary>
	public virtual Constructor DeepCopy()
	{
		//ToDo: Make this a helper method.
		return new Constructor(Name, Cost, BasePoints);
	}

	/// <inheritdoc />
	protected override double ApplyPointsModifiers(double points) => points;

	/// <inheritdoc />
	protected override bool IsEntityValid() => true;

}
