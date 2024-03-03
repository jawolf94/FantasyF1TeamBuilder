
using static Entities.Drivers.DriverPointsModifierHelper;

namespace Entities.Drivers
{
	/// <summary>
	/// Entity representing a Driver. 
	/// </summary>
	public class Driver : TeamComponent
	{

		/// <summary>
		/// Initializes a new instance of a <see cref="Driver"/> with no points awareded on the current race weekend.
		/// </summary>
		public Driver(string name, decimal cost, int qualifyingStreak, int raceStreak, IReadOnlyList<int> previousPointsScored)
			: this(name, cost, 0, qualifyingStreak, raceStreak, previousPointsScored) { }

		/// <summary>
		/// Initializes a new instance of a <see cref="Driver"/>.
		/// </summary>
		public Driver(string name, decimal cost, double points, int qualifyingStreak, int raceStreak, IReadOnlyList<int> previousPointsScored)
			: base(name, cost, qualifyingStreak, raceStreak, previousPointsScored)
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
			var other = new Driver(Name, Cost, BasePoints, QualifyingStreak, RaceStreak, PreviousPointsScored)
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
}
