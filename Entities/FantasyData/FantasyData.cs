
using Entities.Constructors;
using Entities.Drivers;

namespace Entities.FantasyData
{
	/// <summary>
	/// Fantasy data for a driver or constructor retrieved from the Fantasy F1 site.
	/// </summary>
	public class FantasyData : IFantasyData
	{
		/// <inheritdoc />
		public virtual string Name { get; init; }

		/// <inheritdoc />
		public virtual decimal Cost { get; init; }

		/// <inheritdoc />
		public virtual IReadOnlyList<int> RaceWeekPoints { get; init; }

		/// <inheritdoc />
		public virtual int QualifyingStreak { get; init; }

		/// <inheritdoc />
		public virtual int RaceStreak { get; init; }

		/// <summary>
		/// Creates a new instance of <see cref="FantasyData"/> initilaized with the specified parameters.
		/// </summary>
		public FantasyData(string name, decimal cost, IReadOnlyList<int> points, int qualiStreak, int raceStreak)
		{
			Name = name;
			Cost = cost;
			QualifyingStreak = qualiStreak;
			RaceStreak = raceStreak;

			// Copy streak data to avoid referencing the same list.
			var raceWeekPoints = new List<int>();
			raceWeekPoints.AddRange(points);
			RaceWeekPoints = raceWeekPoints;
		}

		/// <summary>
		/// Creates a new instance of <see cref="FantasyData"/> initialized using existing fantasy data.
		/// </summary>
		public FantasyData(IFantasyData fantasyData)
			: this(fantasyData.Name, fantasyData.Cost, fantasyData.RaceWeekPoints, fantasyData.QualifyingStreak, fantasyData.RaceStreak)
		{ }

		/// <summary>
		/// Creates a new instance of <see cref="FantasyData"/> with default result data.
		/// </summary>
		public FantasyData()
			: this("Unknown", Decimal.MaxValue, new List<int>(), 0, 0)
		{ }

		/// <summary>
		/// Converts <see cref="IFantasyData"/> into a <see cref="Driver"/> instance.
		/// </summary>
		public static Driver ToDriver(IFantasyData fantasyData) =>
		   new Driver(fantasyData.Name, fantasyData.Cost, fantasyData.QualifyingStreak, fantasyData.RaceStreak, fantasyData.RaceWeekPoints);

		/// <summary>
		/// Converts <see cref="IFantasyData"/> into a <see cref="Constructor"/> instance.
		/// </summary>
		public static Constructor ToConstructor(IFantasyData fantasyData) =>
		  new Constructor(fantasyData.Name, fantasyData.Cost, fantasyData.QualifyingStreak, fantasyData.RaceStreak, fantasyData.RaceWeekPoints);
	}
}
