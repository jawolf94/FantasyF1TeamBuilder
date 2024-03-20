namespace Results.Data;

/// <summary>s
/// Result data for a  F1 driver
/// </summary>
public record DriverRaceResults : RaceResults
{
	/// <summary>
	/// Creates a new instance of <see cref="ConstructorRaceResults"/> initilaized with the specified parameters.
	/// </summary>
	public DriverRaceResults(string name, IReadOnlyList<int> points) : base(name, points) { }
}
