namespace Results.Data;

/// <summary>s
/// Result data for a F1 constructor
/// </summary>
public record ConstructorRaceResults : RaceResults
{
	/// <summary>
	/// Creates a new instance of <see cref="ConstructorRaceResults"/> initilaized with the specified parameters.
	/// </summary>
	public ConstructorRaceResults(string name, IReadOnlyList<int> points) : base(name, points) { }
}
