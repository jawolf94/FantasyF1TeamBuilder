
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
            :this(name, cost, 0, qualifyingStreak, raceStreak, previousPointsScored) { }

        /// <summary>
        /// Initializes a new instance of a <see cref="Driver"/>.
        /// </summary>
        public Driver(string name, decimal cost, double points, int qualifyingStreak, int raceStreak, IReadOnlyList<int> previousPointsScored)
            :base(name, cost, qualifyingStreak, raceStreak, previousPointsScored)
        {
            BasePoints=points;
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
        /// True if the driver is currently set as the mega driver.
        /// </summary>
        public bool IsMegaDriver => PointsModifier is DriverPointsModifier.Mega;

        /// <summary>
        /// Creates a deep copy of this Driver instance.
        /// </summary>
        public Driver DeepCopy() => DeepCopyInternal();

        /// <inheritdoc />
        protected override double ApplyPointsModifiers(double points)
        {
            return points * GetAppliedModifier(PointsModifier);
        }

        /// <inheritdoc />
        protected override bool IsEntityValid()
        {
            var onlyOnePointModifier = !(IsTurboDriver && IsMegaDriver);

            return onlyOnePointModifier;
        }

        /// <summary>
        /// Internal implementation for creating a deep copy of this instance.
        /// </summary>
        protected virtual Driver DeepCopyInternal()
        {
            var other = new Driver(Name, Cost, BasePoints, QualifyingStreak, RaceStreak, PreviousPointsScored)
            {
                PointsModifier = PointsModifier
            };

            return other;
        }
    }
}
