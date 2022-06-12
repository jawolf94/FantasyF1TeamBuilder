namespace Entities.FantasyData
{
	/// <summary>
	/// Fantasy data for a driver or constructor retrieved from Fantasy F1 site.
	/// </summary>
	public interface IFantasyData
	{
		/// <summary>
		/// Name of the driver or constructor
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Cost of the driver or constructor in millions of dollars
		/// </summary>
		public decimal Cost { get; }

		/// <summary>
		/// Historical fantasy points scored each race weekend. Index 0 is the earliest race.
		/// </summary>
		public IReadOnlyList<int> RaceWeekPoints { get; }

		/// <summary>
		/// Current qualifying streak.
		/// </summary>
		public int QualifyingStreak { get; }

		/// <summary>
		/// Current race streak.
		/// </summary>
		public int RaceStreak { get; }

	}
}