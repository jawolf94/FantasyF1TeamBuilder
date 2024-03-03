
namespace Entities.Constructors
{
	/// <summary>
	/// Entity representing a constructor.
	/// </summary>
	public class Constructor : TeamComponent
	{
		/// <summary>
		/// Initializes a new instance of <see cref="Constructor"/>
		/// </summary>
		public Constructor(string name, decimal cost, int qualifyingStreak, int raceStreak, IReadOnlyList<int> previousPointsScored)
		: this(name, cost, 0, qualifyingStreak, raceStreak, previousPointsScored)
		{
		}

		/// <summary>
		/// Initializes a new instance of <see cref="Constructor"/>
		/// </summary>
		public Constructor(string name, decimal cost, double points, int qualifyingStreak, int raceStreak, IReadOnlyList<int> previousPointsScored)
		: base(name, cost, qualifyingStreak, raceStreak, previousPointsScored)
		{
			BasePoints = points;
		}

		/// <summary>
		/// Creates a copy of this Constructor.
		/// </summary>
		public virtual Constructor DeepCopy()
		{
			return new Constructor(Name, Cost, BasePoints, QualifyingStreak, RaceStreak, PreviousPointsScored);
		}

		/// <inheritdoc />
		protected override double ApplyPointsModifiers(double points) => points;

		/// <inheritdoc />
		protected override bool IsEntityValid() => true;

	}
}
