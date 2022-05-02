using Predictors;

namespace FantasyF1TeamBuilder
{
    /// <summary>
    /// Provides helper methods to output program results
    /// </summary>
    public static class OutputHelper
    {
        /// <summary>
        /// Prints results for about a predicted team.
        /// </summary>
        public static void PrintPredictedTeam(PredictedFantasyTeam team) 
        {
            Console.WriteLine($"Total Score: {team.PredictedPoints} --- Cost: ${team.Cost} \n");

            Console.WriteLine("**** Constructor ****");
            Console.WriteLine($"{team.Constructor.Name} | Predicted Points: {team.Constructor.PredictedPoints} \n");

            Console.WriteLine("**** Dirvers ****");
            foreach (var driver in team.Drivers)
            {
                Console.WriteLine($"- {driver.Name} | Predicted Points: {driver.PredictedPoints}");
            }
        }
    }
}
