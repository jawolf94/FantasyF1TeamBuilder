namespace Entities
{
	/// <summary>
	/// An entity which represents a playable component on a fantasy team. Currently a Driver or Constructor
	/// </summary>
	public abstract class TeamComponent : IValidatable
	{
		/// <summary>
		/// Initializes a new instance of <see cref="TeamComponent"/>
		/// </summary>
		protected TeamComponent(string name, decimal cost, int qualifyingStreak, int raceStreak, IReadOnlyList<int> previousPointsScored)
		{
			Name = name;
			Cost = cost;
			QualifyingStreak = qualifyingStreak;
			RaceStreak = raceStreak;
			InternalPreviousPointsScored = new List<int>(previousPointsScored);
		}

		/// <summary>
		/// Name of the entity.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Cost of the entity (in millions of dollars)
		/// </summary>
		public decimal Cost { get; }

		/// <summary>
		/// Current qualifying streak of the entity.
		/// </summary>
		public int QualifyingStreak { get; }

		/// <summary>
		/// Current race streak of the entity.
		/// </summary>
		public int RaceStreak { get; }

		/// <summary>
		/// True if the entity is valid.
		/// </summary>
		public bool IsValid => IsEntityValid();

		/// <summary>
		/// Fantasy points awarded on the current race weekend including point modifiers.
		/// </summary>
		public double Points => ApplyPointsModifiers(BasePoints);

		/// <summary>
		/// Points awareded on the current race weekend before modifiers.
		/// </summary>
		public double BasePoints { get; protected set; }

		/// <summary>
		/// Record of base fantasy points scored on previous race weekends. No modifiers applied.
		/// Index 0 being the first race of the season.
		/// </summary>
		public IReadOnlyList<int> PreviousPointsScored => InternalPreviousPointsScored;

		/// <summary>
		/// Internal list off fantasy points scored on previous race weekends. No modifiers applied.
		/// Index 0 being the first race of the season.
		/// </summary>
		protected List<int> InternalPreviousPointsScored { get; set; }

		/// <summary>
		/// Returns true if the data represented by this entity is valid according to game rules.
		/// </summary>
		protected abstract bool IsEntityValid();

		/// <summary>
		/// Modifies the points scored accoring to the game rules.
		/// </summary>
		protected abstract double ApplyPointsModifiers(double points);
	}
}
