namespace Results.Data;

/// <summary>
/// Result data for an F1 race entrant.
/// </summary>
public abstract record RaceResults
{

	/// <summary>
	/// Creates a new instance of <see cref="RaceResults"/> initilaized with the specified parameters.
	/// </summary>
	protected RaceResults(string name, IReadOnlyList<int> points)
	{
		Name = name;
		PreviousWeekScores = new List<int>(points);
	}

	/// <summary>
	/// Name of the entrant.
	/// </summary>
	public string Name { get; }

	/// <summary>
	/// Historical fantasy point results. Index 0 is the earliest race.
	/// </summary>
	public IReadOnlyList<int> PreviousWeekScores { get; }
}
