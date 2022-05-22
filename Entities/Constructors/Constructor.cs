
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
        :base(name, cost, qualifyingStreak, raceStreak, previousPointsScored)
        {
            BasePoints = 0;
        }


        /// <inheritdoc />
        protected override double ApplyPointsModifiers(double points) => points;

        /// <inheritdoc />
        protected override bool IsEntityValid() => true;
    }
}
