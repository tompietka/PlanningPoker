using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanningPoker
{
    public class Story
    {

        public List<int> CreateList()
        {
            List<int> playerEstimations = new List<int>();
            return playerEstimations;
        }

        public List<int> NormalizeList(List<int> playerEstimations)
        {
            int minimum = playerEstimations.Min();
            int maximum = playerEstimations.Max();

            playerEstimations.Remove(minimum);
            playerEstimations.Remove(maximum);

            return playerEstimations;
            // throw new NotImplementedException();
        }

        public void AddPlayerEstimation(int playerEstimation, List<int> playerEstimations)
        {
            playerEstimations.Add(playerEstimation);
        }

        public int CalculateEstimationAvgRoundDown(int noPlayers, List<int> playerEstimations)
        {
            return (playerEstimations.Sum()) / noPlayers;
        }

        public int CalculateEstimationMedianRoundDown(int noPlayers, List<int> playerEstimations)
        {
            List<int> sortedNumbers = playerEstimations;
            sortedNumbers.Sort();
            // get median
            int mid = noPlayers / 2;
            int median = (noPlayers % 2 != 0) ? sortedNumbers[mid] : (sortedNumbers[mid] + sortedNumbers[mid - 1]) / 2;
            return median;
        }

        public int CalculateEstimationAvgRoundUp(int noPlayers, List<int> playerEstimations)
        {
            //math
            int estimationSum = playerEstimations.Sum();
            bool dividedEvenly = (estimationSum % noPlayers) == 0;
            if (dividedEvenly)
                return CalculateEstimationAvgRoundDown(noPlayers, playerEstimations);
            bool wasRoundedDown = ((estimationSum > 0) == (noPlayers > 0));

            if (wasRoundedDown)
                return CalculateEstimationAvgRoundDown(noPlayers, playerEstimations) + 1;

            return CalculateEstimationAvgRoundDown(noPlayers, playerEstimations);
        }

        public int CalculateEstimationAllEqual(int noPlayers, List<int> playerEstimations)
        {

            if (playerEstimations.Distinct().Skip(1).Any())
            {
                Console.WriteLine("Estimations need to be equal");
                return 0;
            }
            else
            {
                return CalculateEstimationAvgRoundDown(noPlayers, playerEstimations);
            }
        }
    }


    //public class story
    //{
    //    public void Estimate(EstimationCard estimationCard)
    //    {
    //        var round = Math.Round(2.4, MidpointRounding.AwayFromZero);
    //    }
    //}

    public enum EstimationCard
    {
        Break = -3,
        TooBig = -2,
        Unknown = -1,
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Five = 5,
        Eight = 8,
        Thirteen = 13,

    }
}